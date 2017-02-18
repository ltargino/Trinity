<?php

/**
 * Created by PhpStorm.
 * User: Larissa Targino
 * Date: 18/02/2017
 * Time: 16:59
 */
class Saldo_Usuario
{
    public $ID;
    public $FK_ID_USUARIO;
    public $SALDO_PONTOS;

    /**
     * Saldo_Usuario constructor.
     * @param $ID
     * @param $FK_ID_USUARIO
     * @param $SALDO_PONTOS
     */
    public function __construct($ID, $FK_ID_USUARIO, $SALDO_PONTOS)
    {
        $this->ID = $ID;
        $this->FK_ID_USUARIO = $FK_ID_USUARIO;
        $this->SALDO_PONTOS = $SALDO_PONTOS;
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
    public function getSALDOPONTOS()
    {
        return $this->SALDO_PONTOS;
    }

    /**
     * @param mixed $SALDO_PONTOS
     */
    public function setSALDOPONTOS($SALDO_PONTOS)
    {
        $this->SALDO_PONTOS = $SALDO_PONTOS;
    }

    public function toJSON(){
        return json_encode($this);
    }

}