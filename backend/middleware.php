<?php
$headers = getallheaders();

if (!isset($headers['Authorization'])) {
    die(json_encode(["message" => "Token tidak ada"]));
}

$token = str_replace("Bearer ", "", $headers['Authorization']);
$data = json_decode(base64_decode($token), true);

if ($data['exp'] < time()) {
    die(json_encode(["message" => "Token expired"]));
}
?>