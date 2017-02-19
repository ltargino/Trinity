<?php

require 'Connection.php';
require 'Usuario.php';
require 'Feed.php';
require 'Formas_Pagamentos.php';
require 'Mensagens.php';
require 'Saldo_Usuario.php';
require  'Lancamentos.php';

/**
 * Created by PhpStorm.
 * User: Larissa Targino
 * Date: 18/02/2017
 * Time: 12:49
 */
$Con = new Connection();
$Con->openLink();

$typeQuery = $_GET["type_query"];

header('Content-Type: application/json');

switch ($typeQuery){
    case "Usuario":{
        $respostaUsuario;

        $emailUsuario = $_GET["emailUsuario"];

        $result = mysqli_query($Con->getLink(), "SELECT ID,
                                                                CPF,
                                                                NOME,
                                                                DATA_NASCIMENTO,
                                                                TELEFONE,
                                                                EMAIL,
                                                                SENHA
                                                         FROM Usuario
                                                         WHERE EMAIL = '".$emailUsuario."'" ) or die('Erro ao consultar:  '.$emailUsuario);

        while($row = mysqli_fetch_object($result)){
            $respostaUsuario = new Usuario($row->ID, $row->CPF, $row->NOME, $row->DATA_NASCIMENTO, $row->TELEFONE, $row->EMAIL, $row->SENHA);
        }

        echo $respostaUsuario->toJSON();
        break;
    }
    case "Saldo_Usuario":{
        $respostaSaldo;

        $idUsuario = $_GET["idUsuario"];

        $result = mysqli_query($Con->getLink(), "SELECT ID,
                                                                FK_ID_USUARIO,
                                                                SALDO_PONTOS
                                                         FROM Saldo_Usuario
                                                         WHERE FK_ID_USUARIO = ".$idUsuario ) or die('Erro ao consultar:  '.$idUsuario);

        while($row = mysqli_fetch_object($result)){
            $respostaSaldo = new Saldo_Usuario($row->ID, $row->FK_ID_USUARIO, $row->SALDO_PONTOS);
        }

        echo $respostaSaldo->toJSON();
        break;
    }
    case "Formas_Pagamentos": {
        $respostaFormasPagamento = array();

        $result = mysqli_query($Con->getLink(), "SELECT COD_PAGAMENTO,
                                                                DESCRICACAO_PAGAMENTO
                                                         FROM Formas_Pagamentos") or die('Erro ao consultar.');

        while($row = mysqli_fetch_object($result)){
            $formaPagamentoTemp = new Formas_Pagamentos($row->COD_PAGAMENTO, $row->DESCRICACAO_PAGAMENTO);

            array_push($respostaFormasPagamento, $formaPagamentoTemp);
        }

        echo json_encode($respostaFormasPagamento);
        break;
    }
    case "Mensagens": {
        $respostaMensagens = array();

        $idUsuarioOrigem = $_GET["idUsuarioOrigem"];
        $idUsuarioDestino = $_GET["idUsuarioDestino"];

        $result = mysqli_query($Con->getLink(), "SELECT ID,
                                                        DATA_HORA_MENSAGEM,
                                                        MENSAGEM,
                                                        FK_ID_USUARIO_ORIGEM,
                                                        FK_ID_USUARIO_DESTINO
                                                  FROM Mensagens
                                                  WHERE FK_ID_USUARIO_ORIGEM = ".$idUsuarioOrigem
            ."  AND FK_ID_USUARIO_ORIGEM = ".$idUsuarioDestino) or die('Erro ao consultar.');

        while($row = mysqli_fetch_object($result)){
            $formaMensagemTemp = new Mensagens($row->ID, $row->DATA_HORA_MENSAGEM, $row->MENSAGEM, $row->FK_ID_USUARIO_ORIGEM, $row->FK_ID_USUARIO_DESTINO);

            array_push($respostaMensagens, $formaMensagemTemp);
        }

        echo json_encode($respostaMensagens);
        break;
    }
    case "Feed": {
        $respostaFeed = array();

        $result = mysqli_query($Con->getLink(), "SELECT COD_PUBLICACAO,
                                                                DATA_PUBLICACAO,
                                                                DESCRICAO_FEED,
                                                                FK_ID_USUARIO
                                                          FROM Feed") or die('Erro ao consultar.');


        while($row = mysqli_fetch_object($result)){
            $formaFeedTemp = new Feed($row->COD_PUBLICACAO, $row->DATA_PUBLICACAO, $row->DESCRICAO_FEED, $row->FK_ID_USUARIO);

            array_push($respostaFeed, $formaFeedTemp);
        }

        echo json_encode($respostaFeed);
        break;
    }
    case "Lancamentos": {
        $respostaLancamentos = array();

        $idUsuario = $_GET["idUsuario"];

        $result = mysqli_query($Con->getLink(), "SELECT ID,
                                                        FK_ID_USUARIO,
                                                        CHAVE_SEGURANCA,
                                                        DATA_LACAMENTO,
                                                        PONTOS_USUARIO,
                                                        VALOR_COMPRA,
                                                        STATUS,
                                                        TIPO_PAGAMENTO
                                                   FROM Lacamentos
                                                  WHERE FK_ID_USUARIO= ".$idUsuario) or die('Erro ao consultar.');



        while($row = mysqli_fetch_object($result)){
            $lancamentoTemp = new Lancamentos($row->ID, $row->FK_ID_USUARIO, $row->CHAVE_SEGURANCA, $row->DATA_LACAMENTO, $row->PONTOS_USUARIO, $row->VALOR_COMPRA, $row->STATUS, $row->TIPO_PAGAMENTO);

            array_push($respostaLancamentos, $lancamentoTemp);
        }

        echo json_encode($respostaLancamentos);
        break;
    }

}

$Con->close()
?>


