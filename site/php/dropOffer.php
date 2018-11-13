<?php
	if(isset($_POST['id'])) {
		
		include "DB_Request.php";
		$link = Connect();
				
		$query = "DELETE FROM offer WHERE id = ".$_POST['id'];
		Request($link, $query);
		
		$delQuery = "DELETE FROM offeredmeals WHERE offerId = ".$_POST['id'];
		Request($link, $delQuery);
	}
?>
