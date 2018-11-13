<?php
	
	$redirectMenu = '<script>setTimeout(function(){ document.location = "../menu.php"; }, 2500);</script>';
	
	include "DB_Request.php";
	$link = Connect();
	
	function pushOrder($name, $surname, $phone, $city, $avenue, $building, $flat, $comment, $meals, $mail) {
		
		$link = Connect();
		
		$query = "SELECT MAX(id) FROM offer";
		$id = mysqli_fetch_array(Request($link, $query), MYSQLI_NUM)[0] + 1;
		
		$start = date("Y-n-j H:i:s");
		
		$queryPush = "INSERT INTO offer VALUES('".$id."', '".$name."', '".$surname."', '".$phone."', '".$city."', '".$avenue."', '".$building."', '".$flat."', '".$comment."', '".$start."', '".$_COOKIE['total']."', 0, 0, 0);";
		Request($link, $queryPush);
		
		$offeredMealId = (int)(mysqli_fetch_array(Request($link, "SELECT MAX(id) FROM offeredmeals"), MYSQLI_NUM)[0]) + 1;
		
		foreach($meals as $meal) {
				
			$usedProducts = "";
			
			foreach($meal['products'] as $product) {
				
				$storeProductsQuery = "SELECT storage.id, storage.amount, product.id AS productId FROM product, storage WHERE product.id = storage.productId AND product.id = ".$product['id'];
				$storedProducts = Request($link, $storeProductsQuery);
				$needAmount = $product['count'] * $meal['count'];
				
				while($stored = mysqli_fetch_array($storedProducts, MYSQLI_ASSOC)) {
					
					if($needAmount > $stored['amount']) {
						
						$usedProducts .= $stored['id'].' '.$stored['productId'].' '.$stored['amount'].';';
						$needAmount -= $stored['amount'];
						$deleteQuery = "DELETE FROM storage WHERE id = ".$stored['id'];
						Request($link, $deleteQuery);
					}
					else {
						
						$usedProducts .= $stored['id'].' '.$stored['productId'].' '.$needAmount.';';
						$updateQuery = "UPDATE storage SET amount = ".($stored['amount'] - $needAmount)." WHERE id = ".$stored['id'];
						Request($link, $updateQuery);
						$needAmount = 0;
						break;
					}
				}
			}
					
			$queryPushMeal = "INSERT INTO offeredmeals VALUES('".$offeredMealId."', '".$id."', '".$meal['id']."', '".$meal['count']."', '".$usedProducts."', 0, 0);";
			Request($link, $queryPushMeal);
			$offeredMealId++;
		}
		
		include "mailSender.php";
		mailSend($mail, $id);
		
		echo "<html><head><link rel='stylesheet' href='../css/main.css'></head><body><center><div class = 'afterOfferDiv'><text>Ваш заказ принят! ID заказа: ".$id."</text></div></center></body><script>setTimeout(function(){ document.location = '../offer.php?id=".$id."'; }, 2500);</script></html>";
	}
	
	if(isset($_POST['name']) && isset($_POST['surname']) && isset($_POST['phone']) && isset($_POST['city']) && isset($_POST['avenue']) && isset($_POST['building']) && isset($_POST['flat']) && isset($_POST['mail']) &&
	   $_POST['name'] != "" && $_POST['surname'] != "" && $_POST['phone'] != "" && $_POST['city'] != "" && $_POST['avenue'] != "" && $_POST['building'] != "" && $_POST['flat'] != "" && $_POST['mail'] != "" &&
	   isset($_COOKIE['bought']) && $_COOKIE['bought'] != "" && $_COOKIE['bought'] != "{ }" && $_COOKIE['bought'] != null && 
	   isset($_COOKIE['total']) && $_COOKIE['total'] != 0 && $_COOKIE['total'] != null) {
		
		$productEnough = true;
		$boughtMeals = [];
		
		foreach(json_decode($_COOKIE['bought'], true) as $key => $value) {
			
			$query = "SELECT menu.weight, meal.weight AS mealWeight FROM menu, meal WHERE menu.mealId = meal.id AND menu.id = ".$key;
			$result = Request($link, $query);
			$meal = mysqli_fetch_array($result, MYSQLI_ASSOC);
			
			$productsQuerySample = "SELECT product.id, product.name, recipeingrs.count, product.unit, recipeingrs.fixMode FROM product, recipeingrs, menu WHERE product.id = recipeingrs.productId AND recipeingrs.mealId = menu.mealId AND menu.id = ".$key;
			$products = Request($link, $productsQuerySample);
			
			$boughtMeal = [];
			$boughtMeal['id'] = $key;
			$boughtMeal['count'] = $value;
			$boughtMeal['products'] = [];
			
			while($product = mysqli_fetch_array($products, MYSQLI_ASSOC)) {
				
				$totalAmount = 0;
				$storeProductsQuery = "SELECT product.name, storage.amount FROM product, storage WHERE product.id = storage.productId AND product.id = ".$product['id'];
				$storedProducts = Request($link, $storeProductsQuery);
				
				while($stored = mysqli_fetch_array($storedProducts, MYSQLI_ASSOC))
					$totalAmount += $stored['amount'];
				
				$realCount = $product['fixMode'] == 0 ? $product['count'] : ($product['fixMode'] == 1 ? ceil($product['count'] * $meal['weight'] / $meal['mealWeight']) : (int)($product['count'] * $meal['weight'] / $meal['mealWeight']));
				
				$productBought = [];
				$productBought['id'] = $product['id'];
				$productBought['count'] = $realCount;
				
				array_push($boughtMeal['products'], $productBought);
						
				if($totalAmount < $realCount * $value) {
							
					$productEnough = false;
					break;
				}
			}
			
			if(!$productEnough) {
				
				echo "<html><head><link rel='stylesheet' href='../css/main.css'></head><body><center><div class = 'afterOfferDiv'><text>Извините, на складе недостаточно продуктов!</text></div></center></body>".$redirectMenu."</html>";
				break;
			}
			
			array_push($boughtMeals, $boughtMeal);
		}
		if($productEnough)
			echo pushOrder($_POST['name'], $_POST['surname'], $_POST['phone'], $_POST['city'], $_POST['avenue'], $_POST['building'], $_POST['flat'], $_POST['comment'], $boughtMeals, $_POST['mail']);
	}
	else
		echo "<html><head><link rel='stylesheet' href='../css/main.css'></head><body><center><div class = 'afterOfferDiv'><text>Ваш заказ был пуст!</text></div></center></body>".$redirectMenu."</html>";
	
	include "dropCart.php";
?>