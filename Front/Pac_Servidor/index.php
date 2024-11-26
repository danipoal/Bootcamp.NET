<!DOCTYPE html>
<html>
<head>
    <title>Posts</title>
</head>
<body>
<?php require_once 'controller.php'; ?>

    <h1>Posts</h1>
    <table> 
		<tr>
			<th>User</th>
			<th>Título</th>
			<th>Texto</th>
		</tr>
	<?php
    /* Llamamos a la función correspondiente
       para mostrar los posts */
    showPosts(); 
    ?>
	</table>

    <h2>Add a new post</h2>
    <form action="controller.php" method="POST">
        <label for="user">User:</label>
        <input type="text" name="user"><br>
        <label for="title">Title:</label>
        <input type="text" name="title"><br>
        <label for="body">Body:</label>
        <textarea name="body" ></textarea><br>
        <button type="submit">Add Post</button>
    </form>
</body>
</html>
