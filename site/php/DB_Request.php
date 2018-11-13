<?php
	
	function Connect() {
	
		$host = 'localhost';
		$database = 'delicious_dishes';
		$user = 'root';
		$password = 'masterkey';
		
		/*$host = 'mysql.zzz.com.ua';
		$database = 'delicious_dishes';
		$user = 'Dishes';
		$password = '228Delishes';*/

		$link = mysqli_connect($host, $user, $password, $database)
			or die("Ошибка ".mysqli_error($link));
			
		return $link;
	}
	
	function Request($link, $query) {
		
		return mysqli_query($link, $query);
	}
?>