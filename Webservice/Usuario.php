<?php
class Usuario
{

    public $ID;
    public $CPF;
    public $Nome;
    public $Data_Nascimento;
    public $Telefone;
    public $Email;
    public $Senha;

    /**
     * Usuario constructor.
     * @param $ID
     * @param $CPF
     * @param $Nome
     * @param $Data_Nascimento
     * @param $Telefone
     * @param $Email
     * @param $Senha
     */
    public function __construct($ID, $CPF, $Nome, $Data_Nascimento, $Telefone, $Email, $Senha)
    {
        $this->ID = $ID;
        $this->CPF = $CPF;
        $this->Nome = $Nome;
        $this->Data_Nascimento = $Data_Nascimento;
        $this->Telefone = $Telefone;
        $this->Email = $Email;
        $this->Senha = $Senha;
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
    public function getCPF()
    {
        return $this->CPF;
    }

    /**
     * @param mixed $CPF
     */
    public function setCPF($CPF)
    {
        $this->CPF = $CPF;
    }

    /**
     * @return mixed
     */
    public function getNome()
    {
        return $this->Nome;
    }

    /**
     * @param mixed $Nome
     */
    public function setNome($Nome)
    {
        $this->Nome = $Nome;
    }

    /**
     * @return mixed
     */
    public function getDataNascimento()
    {
        return $this->Data_Nascimento;
    }

    /**
     * @param mixed $Data_Nascimento
     */
    public function setDataNascimento($Data_Nascimento)
    {
        $this->Data_Nascimento = $Data_Nascimento;
    }

    /**
     * @return mixed
     */
    public function getTelefone()
    {
        return $this->Telefone;
    }

    /**
     * @param mixed $Telefone
     */
    public function setTelefone($Telefone)
    {
        $this->Telefone = $Telefone;
    }

    /**
     * @return mixed
     */
    public function getEmail()
    {
        return $this->Email;
    }

    /**
     * @param mixed $Email
     */
    public function setEmail($Email)
    {
        $this->Email = $Email;
    }

    /**
     * @return mixed
     */
    public function getSenha()
    {
        return $this->Senha;
    }

    /**
     * @param mixed $Senha
     */
    public function setSenha($Senha)
    {
        $this->Senha = $Senha;
    }

    public function toJSON(){
        return json_encode($this);
    }

}