<?php
// Create connection
$connection = mysqli_connect('localhost','bence', 'abc123', 'dolgozodb', 3306);

// Check connection
if (!$connection) {
	die("Connection failed: " . mysqli_connect_error());
}
?>