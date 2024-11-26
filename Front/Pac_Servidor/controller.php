<?php
require_once 'model.php';

/* Validamos si la página contiene información del formulario y,
   en ese caso, añadimos el post a nuestra base de datos */
if (isset($_POST['user']) && isset($_POST['title']) && isset($_POST['body']) ) {
    addPost($_POST['user'], $_POST['title'], $_POST['body']);
    header("Location: index.php");
    exit();
}

/* Función para mostrar los posts en la tabla */
function showPosts() {
    $datos = getPosts();
    if (is_string($datos)) {
        echo $datos;
    } else {
        while ($fila = mysqli_fetch_assoc($datos)) {
            echo "<tr>\n
                    <td>" . $fila["user"] . "</td>\n
                    <td>" . $fila["title"] . "</td>\n
                    <td>" . $fila["body"] . "</td>\n
                </tr>";
        }
    }
}
?>