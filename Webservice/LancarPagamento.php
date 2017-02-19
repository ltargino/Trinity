<?php
require 'Lancamentos.php';
require 'Connection.php';

/**
 * Created by PhpStorm.
 * User: Larissa Targino
 * Date: 19/02/2017
 * Time: 00:32
 */
$Con = new Connection();
$Con->openLink();

$json_Lancamento = $_GET["json_Lancamento"];

$Lancamento_to_insert = json_decode($json_Lancamento);

$result = mysqli_query($Con->getLink(), "INSERT INTO Lacamentos (ID,
                                                                  FK_ID_USUARIO,
                                                                  CHAVE_SEGURANCA,
                                                                  DATA_LACAMENTO,
                                                                  PONTOS_USUARIO,
                                                                  VALOR_COMPRA,
                                                                  STATUS,
                                                                  TIPO_PAGAMENTO) 
                                                       VALUES (".$Lancamento_to_insert->ID.", "
    ."".$Lancamento_to_insert->FK_ID_USUARIO.", "
    ."'".$Lancamento_to_insert->CHAVE_SEGURANCA."', "
    ."'".$Lancamento_to_insert->DATA_LANCAMENTO."', "
    ."".$Lancamento_to_insert->PONTOS_USUARIO.", "
    ."".$Lancamento_to_insert->VALOR_COMPRA.", "
    ."'".$Lancamento_to_insert->STATUS."', "
    ."'".$Lancamento_to_insert->TIPO_PAGAMENTO."')") or die('Erro ao cadastrar.');

echo $result;

$Con->close()
?>