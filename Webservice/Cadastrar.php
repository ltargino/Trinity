<?php
require 'Usuario.php';
require 'Connection.php';

/**
 * Created by PhpStorm.
 * User: Larissa Targino
 * Date: 18/02/2017
 * Time: 22:45
 */
$Con = new Connection();
$Con->openLink();

$json_usuarioCadastro = $_GET["json_usuarioCadastro"];

$user_to_insert = json_decode($json_usuarioCadastro);

$result = mysqli_query($Con->getLink(), "INSERT INTO Usuario (ID,
                                                              CPF,
                                                              NOME,
                                                              DATA_NASCIMENTO,
                                                              TELEFONE,
                                                              EMAIL,
                                                              SENHA) 
                                                       VALUES (".$user_to_insert->ID.", "
    ."'".$user_to_insert->CPF."', "
    ."'".$user_to_insert->NOME."', "
    ."'".$user_to_insert->DATA_NASCIMENTO."', "
    ."'".$user_to_insert->TELEFONE."', "
    ."'".$user_to_insert->EMAIL."', "
    ."'".$user_to_insert->SENHA."')") or die('Erro ao cadastrar.');

echo $result;

$Con->close()
?>
