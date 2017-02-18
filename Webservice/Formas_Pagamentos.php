<?php

/**
 * Created by PhpStorm.
 * User: Larissa Targino
 * Date: 18/02/2017
 * Time: 16:54
 */
class Formas_Pagamentos
{

    public $COD_PAGAMENTO;
    public $DESCRICAO_PAGAMENTO;

    /**
     * Formas_Pagamentos constructor.
     * @param $COD_PAGAMENTO
     * @param $DESCRICAO_PAGAMENTO
     */
    public function __construct($COD_PAGAMENTO, $DESCRICAO_PAGAMENTO)
    {
        $this->COD_PAGAMENTO = $COD_PAGAMENTO;
        $this->DESCRICAO_PAGAMENTO = $DESCRICAO_PAGAMENTO;
    }

    /**
     * @return mixed
     */
    public function getCODPAGAMENTO()
    {
        return $this->COD_PAGAMENTO;
    }

    /**
     * @param mixed $COD_PAGAMENTO
     */
    public function setCODPAGAMENTO($COD_PAGAMENTO)
    {
        $this->COD_PAGAMENTO = $COD_PAGAMENTO;
    }

    /**
     * @return mixed
     */
    public function getDESCRICAOPAGAMENTO()
    {
        return $this->DESCRICAO_PAGAMENTO;
    }

    /**
     * @param mixed $DESCRICAO_PAGAMENTO
     */
    public function setDESCRICAOPAGAMENTO($DESCRICAO_PAGAMENTO)
    {
        $this->DESCRICAO_PAGAMENTO = $DESCRICAO_PAGAMENTO;
    }

    public function toJSON(){
        return json_encode($this);
    }

}