<!DOCTYPE html>
<html lang="en">
	<head>
		<meta charset="UTF-8">
		<title>Luxury Restaurant</title>
		<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/css/bootstrap.min.css" integrity="sha384-PsH8R72JQ3SOdhVi3uxftmaW6Vc51MKb0q5P2rRUpPvrszuE4W1povHYgTpBfshb" crossorigin="anonymous">
		<link href="https://fonts.googleapis.com/css?family=Playfair+Display:700|Sintony:400,700" rel="stylesheet">
		<link rel="stylesheet" href="css/main.css">
		<script src = "js/libs/glm-ajax.js"></script>
		<script src = "js/libs/jquery-3.3.1.js"></script>
	</head>
	<body>
    <header id="header" class="header">
		<div class="main-header">
			<table class="menu-table">
					<tr>
					    <td class ="menu_item">
						    <img src="img/logo.png">
						</td>
					    <td class="menu__item" id="ibt">
						    <a href="index.html">
							    Главная
						    </a>
					    </td>
						<td class="menu__item" id="cbt">
						    <a href="contacts.html">
							    О нас
						    </a>
					    </td>
					    <td class="menu__item" id="mbt">
						    <a href="menu.php">
							    Меню
						    </a>
					    </td>
					    <td class="menu__item1">
						<button class="book cta d-flex justify-content-center" onclick = 'document.location = "cart.php";'>
							<span class="book__icon"></span>
							Корзина
						</button>
						</td>
					</tr>
			</table>
		</div>
    </header>
		<?php

			include "php/DB_Request.php";
			$link = Connect();
			
			$query = "SELECT menu.id, meal.name, meal.descr, menu.price, menu.weight, meal.weight AS mealWeight, meal.id AS mealId FROM menu, meal WHERE menu.mealId = meal.id";
			$result = Request($link, $query);
			
			$productsQuerySample = "SELECT product.id, product.name, recipeingrs.count, product.unit, recipeingrs.fixMode FROM product, recipeingrs WHERE product.id = recipeingrs.productId AND recipeingrs.mealId = ";
			
			$meals = [];
			
			while($meal = mysqli_fetch_array($result, MYSQLI_ASSOC)) {
				
				$meal['products'] = [];
				$productEnough = true;
				$products = Request($link, $productsQuerySample.$meal['mealId']);
				
				while($product = mysqli_fetch_array($products, MYSQLI_ASSOC)) {
					
					$totalAmount = 0;
					$storeProductsQuery = "SELECT product.name, storage.amount FROM product, storage WHERE product.id = storage.productId AND product.id = ".$product['id'];
					$storedProducts = Request($link, $storeProductsQuery);
					while($stored = mysqli_fetch_array($storedProducts, MYSQLI_ASSOC))
						$totalAmount += $stored['amount'];
					
					$product['realCount'] = $product['fixMode'] == 0 ? $product['count'] : ($product['fixMode'] == 1 ? ceil($product['count'] * $meal['weight'] / $meal['mealWeight']) : (int)($product['count'] * $meal['weight'] / $meal['mealWeight']));
					
					if($totalAmount < $product['realCount']) {
						
						$productEnough = false;
						break;
					}
					
					array_push($meal['products'], $product);
				}
				
				if($productEnough)
					array_push($meals, $meal);
			}
			
			$rowCounter = 0;
		?>

		<center>
		
			<table width="70%" bgcolor="#FFFFFF" style = "margin-bottom : 30%; border : 0px;" cellpadding = '8em'>
			
				<hr/>
					<header><div class = "menuHeader">МЕНЮ</div></header>
				<hr/>	
				<tr style = "border-bottom : 1px solid rgb(229, 229, 229);">
					<th><center><div class = 'menuTH'>Название</div></center></th>
					<th><center><div class = 'menuTH'>Ингредиенты</div></center></th>
					<th><center><div class = 'menuTH'>Описание</div></center></th>
					<th><center><div class = 'menuTH'>Цена</div></center></th>
					<th><center><div class = 'menuTH'>Вес</div></center></th>
					<th><center><div class = 'menuTH'>Количество</div></center></th>
					<th><center><div class = 'menuTH'></div></center></th>
				</tr>
				<?php for($i = 0; $i < count($meals); $i++): ?>
					<tr style = "border-bottom : 1px solid rgb(229, 229, 229);">
						<td><center><div class = 'nameCell'><?php echo $meals[$i]['name']; ?></div></center></td>
						<td>
							<center>
								<div class = 'ingrsCell'>
									<?php foreach($meals[$i]['products'] as $product) : ?>
										<center>
											<?php echo $product['name'].' : '.$product['realCount'].' '.$product['unit']; ?>
										</center>
									<?php endforeach; ?>
								</div>
							</center>
						</td>
						<td><center><div class = 'descrCell'><?php echo $meals[$i]['descr']; ?></div></center></td>
						<td><center><div class = 'priceCell'><?php echo $meals[$i]['price']; ?> грн.</div></center></td>
						<td><center><div class = 'weightCell'><?php echo $meals[$i]['weight']; ?> гр.</div></center></td>
						<td><center><input type = 'number' min = '0' value = '0' class = 'countOfMealsInput' id = 'countOfMealsInput<?php echo $i; ?>' style = 'width : 75%'></input></center></td>
						<td><center><button class = 'buyButton' onclick = 'buyMeal("<?php echo (int)($meals[$i]['id']); ?>", document.getElementById("countOfMealsInput<?php echo $i; ?>").value, buyFlagUp, "cartAddFlag<?php echo $i; ?>");'>Купить!</button></center></td>
						<td><center><button class = 'cta' id = 'cartAddFlag<?php echo $i; ?>' style = 'opacity : 0;'>Добавлено в корзину</button></center></td>
					</tr>
				<?php endfor; ?>
				
			</table>
			
		</center>

		<footer id="footer" class="footer">
			<div class="container">
				<div class="row">
					<div class="col-lg-12">
						<ul class="socials d-flex justify-content-center">
							<li class="socials__item socials__item_fb">
								<a href="#"></a>
							</li>
							<li class="socials__item socials__item_tw">
								<a href="#"></a>
							</li>
							<li class="socials__item socials__item_g">
								<a href="#"></a>
							</li>
						</ul>
					</div>
				</div>
				<div class="row">
					<div class="col-lg-4">
						<div class="line"></div>
					</div>
					<div class="col-lg-4">
						<div class="credits">
							2018 ©   All rights reserved
						</div>
					</div>
					<div class="col-lg-4">
						<div class="line"></div>
					</div>
				</div>
			</div>
		</footer>
	</body>
	<script src = "js/buyMeal.js"></script>
	<script src = "js/main.js"></script>
</html>