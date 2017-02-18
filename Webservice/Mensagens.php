<?php

/**
 * Created by PhpStorm.
 * User: Larissa Targino
 * Date: 18/02/2017
 * Time: 16:57
 */
class Mensagens
{
    public $ID;
    public $DATA_HORA_MENSAGEM;
    public $MENSAGEM;
    public $FK_ID_USUARIO_ORIGEM;
    public $FK_ID_USUARIO_DESTINO;

    /**
     * Mensagens constructor.
     * @param $ID
     * @param $DATA_HORA_MENSAGEM
     * @param $MENSAGEM
     * @param $FK_ID_USUARIO_ORIGEM
     * @param $FK_ID_USUARIO_DESTINO
     */
    public function __construct($ID, $DATA_HORA_MENSAGEM, $MENSAGEM, $FK_ID_USUARIO_ORIGEM, $FK_ID_USUARIO_DESTINO)
    {
        $this->ID = $ID;
        $this->DATA_HORA_MENSAGEM = $DATA_HORA_MENSAGEM;
        $this->MENSAGEM = $MENSAGEM;
        $this->FK_ID_USUARIO_ORIGEM = $FK_ID_USUARIO_ORIGEM;
        $this->FK_ID_USUARIO_DESTINO = $FK_ID_USUARIO_DESTINO;
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
    public function getDATAHORAMENSAGEM()
    {
        return $this->DATA_HORA_MENSAGEM;
    }

    /**
     * @param mixed $DATA_HORA_MENSAGEM
     */
    public function setDATAHORAMENSAGEM($DATA_HORA_MENSAGEM)
    {
        $this->DATA_HORA_MENSAGEM = $DATA_HORA_MENSAGEM;
    }

    /**
     * @return mixed
     */
    public function getMENSAGEM()
    {
        return $this->MENSAGEM;
    }

    /**
     * @param mixed $MENSAGEM
     */
    public function setMENSAGEM($MENSAGEM)
    {
        $this->MENSAGEM = $MENSAGEM;
    }

    /**
     * @return mixed
     */
    public function getFKIDUSUARIOORIGEM()
    {
        return $this->FK_ID_USUARIO_ORIGEM;
    }

    /**
     * @param mixed $FK_ID_USUARIO_ORIGEM
     */
    public function setFKIDUSUARIOORIGEM($FK_ID_USUARIO_ORIGEM)
    {
        $this->FK_ID_USUARIO_ORIGEM = $FK_ID_USUARIO_ORIGEM;
    }

    /**
     * @return mixed
     */
    public function getFKIDUSUARIODESTINO()
    {
        return $this->FK_ID_USUARIO_DESTINO;
    }

    /**
     * @param mixed $FK_ID_USUARIO_DESTINO
     */
    public function setFKIDUSUARIODESTINO($FK_ID_USUARIO_DESTINO)
    {
        $this->FK_ID_USUARIO_DESTINO = $FK_ID_USUARIO_DESTINO;
    }

    public function toJSON(){
        return json_encode($this);
    }


}