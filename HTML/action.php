<!DOCTYPE html>
<html lang="en">

<head>

    <title>results</title>
</head>

<body>
    <?php 
if (isset($_POST["voornaam"]) && isset($_POST["achternaam"])) {
    $voornaam = $_POST["voornaam"];
    $achternaam = $_POST["achternaam"];
    echo "<h2>Hallo $voornaam<h2> <br>";
    echo "<h2>Jouw naam is $voornaam<h2> <br>";
    echo "<h2>Jouw achternaam is $achternaam<h2> <br>";
}
if (isset($_POST["button1"])){
    button1();
}
function button1(){
    $voornaam = $_POST["voornaam"];
    $achternaam =$_POST["achternaam"];
}





?>
</body>

</html>