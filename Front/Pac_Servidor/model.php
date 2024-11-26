<?php

include_once "bbdd.php";

function crearConexion() {
    $conexion = mysqli_connect(HOST, USER, PASSWORD, DATABASE);
    if (!$conexion) {
        die("Error de conexión: " . mysqli_connect_error());
    }
    return $conexion;
}

function getPosts() {
    $db = crearConexion();
    $sql = "SELECT * FROM posts";
    $result = mysqli_query($db, $sql);
    mysqli_close($db);
    if (mysqli_num_rows($result) > 0) {
        return $result;
    } else {
        return "No hay posts";
    }
}

function addPost($user, $title, $body) {
    $db = crearConexion();
    $sql = "INSERT INTO posts (user, title, body) VALUES ('$user','$title','$body' )";
    $result = mysqli_query($db, $sql);
    mysqli_close($db);
    if ($result) {
        return $result;
    } else {
        echo "Error al crear post.";
    } 
}
