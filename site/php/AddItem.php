<?php
    if(isset($_POST["name"]) && isset($_POST["ingrs"]) && isset($_POST["desc"]) && isset($_POST["price"]) && isset($_POST["weight"]) && isset($_POST['time']) && isset($_POST['categ']))
    {
	include "DB_Request.php";
        $link = Connect();
	
	$maxID = mysqli_fetch_array(Request($link, "SELECT (MAX(id) + 1) AS id FROM meal"), MYSQLI_ASSOC)['id'];
	$mealId = mysqli_fetch_array(Request($link, "SELECT IF(COUNT(MEALS.id) = 1, MEALS.id, ".$maxID.") AS id FROM (SELECT id, MAX(id) FROM meal WHERE name = '".$_POST["name"]."') MEALS"), MYSQLI_ASSOC)['id'];
	
	if($mealId == $maxID) {
	    
	    $InsMeal = "INSERT INTO meal VALUES(".$mealId.", '".$_POST['name']."', '".$_POST['categ']."', '".$_POST['desc']."', '".$_POST['weight']."', ".$_POST['time'].");";
	    Request($link, $InsMeal);
	    
	    $recId = mysqli_fetch_array(Request($link, "SELECT MAX(id) FROM recipeingrs"), MYSQLI_ASSOC)['MAX(id)'] + 1;

	    for($i = 0; $i < $_POST['ingrs']; $i++) {

		$productId = mysqli_fetch_array(Request($link, "SELECT id FROM product WHERE name = '".$_POST["ingr".$i]."'"), MYSQLI_ASSOC)['id'];
		$InsRec = "INSERT INTO recipeingrs VALUES(".$recId.", '".$mealId."', '".$productId."', '".$_POST["ingrC".$i]."', '1');";
		Request($link, $InsRec);
		$recId++;
	    }
	}
	
	$menuId = mysqli_fetch_array(Request($link, "SELECT MAX(id) FROM menu"), MYSQLI_ASSOC)['MAX(id)'] + 1;
        $InsMenu = "INSERT INTO menu VALUES(".$menuId.", '".$mealId."', '".$_POST['price']."', '".$_POST["weight"]."');";
        Request($link, $InsMenu);
    }
    else echo "<html><link rel='stylesheet' href='../css/main.css'><h1>Неверно введенные данные</h1><html>";

?>
