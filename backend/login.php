<?php
include "db.php";
include "config.php";

$data = json_decode(file_get_contents("php://input"));

$username = $data->username;
$password = $data->password;

$sql = "SELECT * FROM users WHERE username='$username'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    $user = $result->fetch_assoc();

    if (password_verify($password, $user['password'])) {
        $token = base64_encode(json_encode([
            "id" => $user['id'],
            "username" => $user['username'],
            "exp" => time() + 3600
        ]));

        echo json_encode([
            "message" => "Login berhasil",
            "token" => $token
        ]);
    } else {
        echo json_encode(["message" => "Password salah"]);
    }
} else {
    echo json_encode(["message" => "User tidak ditemukan"]);
}
?>