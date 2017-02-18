<?php

/**
 * Created by PhpStorm.
 * User: Larissa Targino
 * Date: 18/02/2017
 * Time: 16:55
 */
class Feed
{
    public $COD_PUBLICACAO;
    public $DATA_PUBLICACAO;
    public $DESCRICAO_FEED;

    /**
     * Feed constructor.
     * @param $COD_PUBLICACAO
     * @param $DATA_PUBLICACAO
     * @param $DESCRICAO_FEED
     */
    public function __construct($COD_PUBLICACAO, $DATA_PUBLICACAO, $DESCRICAO_FEED)
    {
        $this->COD_PUBLICACAO = $COD_PUBLICACAO;
        $this->DATA_PUBLICACAO = $DATA_PUBLICACAO;
        $this->DESCRICAO_FEED = $DESCRICAO_FEED;
    }

    /**
     * @return mixed
     */
    public function getCODPUBLICACAO()
    {
        return $this->COD_PUBLICACAO;
    }

    /**
     * @param mixed $COD_PUBLICACAO
     */
    public function setCODPUBLICACAO($COD_PUBLICACAO)
    {
        $this->COD_PUBLICACAO = $COD_PUBLICACAO;
    }

    /**
     * @return mixed
     */
    public function getDATAPUBLICACAO()
    {
        return $this->DATA_PUBLICACAO;
    }

    /**
     * @param mixed $DATA_PUBLICACAO
     */
    public function setDATAPUBLICACAO($DATA_PUBLICACAO)
    {
        $this->DATA_PUBLICACAO = $DATA_PUBLICACAO;
    }

    /**
     * @return mixed
     */
    public function getDESCRICAOFEED()
    {
        return $this->DESCRICAO_FEED;
    }

    /**
     * @param mixed $DESCRICAO_FEED
     */
    public function setDESCRICAOFEED($DESCRICAO_FEED)
    {
        $this->DESCRICAO_FEED = $DESCRICAO_FEED;
    }

    public function toJSON(){
        return json_encode($this);
    }


}