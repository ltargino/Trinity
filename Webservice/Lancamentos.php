<?php

/**
 * Created by PhpStorm.
 * User: Larissa Targino
 * Date: 18/02/2017
 * Time: 20:09
 */
class Lancamentos
{

    public $ID;
    public $FK_ID_USUARIO;
    public $CHAVE_SEGURANCA;
    public $DATA_LANCAMENTO;
    public $PONTOS_USUARIO;
    public $VALOR_COMPRA;
    public $STATUS;

    /**
     * Lancamentos constructor.
     * @param $ID
     * @param $FK_ID_USUARIO
     * @param $CHAVE_SEGURANCA
     * @param $DATA_LANCAMENTO
     * @param $PONTOS_USUARIO
     * @param $VALOR_COMPRA
     * @param $STATUS
     */
    public function __construct($ID, $FK_ID_USUARIO, $CHAVE_SEGURANCA, $DATA_LANCAMENTO, $PONTOS_USUARIO, $VALOR_COMPRA, $STATUS)
    {
        $this->ID = $ID;
        $this->FK_ID_USUARIO = $FK_ID_USUARIO;
        $this->CHAVE_SEGURANCA = $CHAVE_SEGURANCA;
        $this->DATA_LANCAMENTO = $DATA_LANCAMENTO;
        $this->PONTOS_USUARIO = $PONTOS_USUARIO;
        $this->VALOR_COMPRA = $VALOR_COMPRA;
        $this->STATUS = $STATUS;
    }

    /**
     * @return mixed
     */
    public function getID()
    {
        return $this->ID;
    }

    /**
     * @param mixed $ID
     */
    public function setID($ID)
    {
        $this->ID = $ID;
    }

    /**
     * @return mixed
     */
    public function getFKIDUSUARIO()
    {
        return $this->FK_ID_USUARIO;
    }

    /**
     * @param mixed $FK_ID_USUARIO
     */
    public function setFKIDUSUARIO($FK_ID_USUARIO)
    {
        $this->FK_ID_USUARIO = $FK_ID_USUARIO;
    }

    /**
     * @return mixed
     */
    public function getCHAVESEGURANCA()
    {
        return $this->CHAVE_SEGURANCA;
    }

    /**
     * @param mixed $CHAVE_SEGURANCA
     */
    public function setCHAVESEGURANCA($CHAVE_SEGURANCA)
    {
        $this->CHAVE_SEGURANCA = $CHAVE_SEGURANCA;
    }

    /**
     * @return mixed
     */
    public function getDATALANCAMENTO()
    {
        return $this->DATA_LANCAMENTO;
    }

    /**
     * @param mixed $DATA_LANCAMENTO
     */
    public function setDATALANCAMENTO($DATA_LANCAMENTO)
    {
        $this->DATA_LANCAMENTO = $DATA_LANCAMENTO;
    }

    /**
     * @return mixed
     */
    public function getPONTOSUSUARIO()
    {
        return $this->PONTOS_USUARIO;
    }

    /**
     * @param mixed $PONTOS_USUARIO
     */
    public function setPONTOSUSUARIO($PONTOS_USUARIO)
    {
        $this->PONTOS_USUARIO = $PONTOS_USUARIO;
    }

    /**
     * @return mixed
     */
    public function getVALORCOMPRA()
    {
        return $this->VALOR_COMPRA;
    }

    /**
     * @param mixed $VALOR_COMPRA
     */
    public function setVALORCOMPRA($VALOR_COMPRA)
    {
        $this->VALOR_COMPRA = $VALOR_COMPRA;
    }

    /**
     * @return mixed
     */
    public function getSTATUS()
    {
        return $this->STATUS;
    }

    /**
     * @param mixed $STATUS
     */
    public function setSTATUS($STATUS)
    {
        $this->STATUS = $STATUS;
    }

    public function toJSON(){
        return json_encode($this);
    }

}