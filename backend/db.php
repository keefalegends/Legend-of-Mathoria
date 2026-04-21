<?php
$conn = new mysqli("localhost", "root", "", "mathoria");

if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}
?>