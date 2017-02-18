<?php

/**
 * Created by PhpStorm.
 * User: Larissa Targino
 * Date: 18/02/2017
 * Time: 12:52
 */
class Connection
{
    private $host;
    private $user;
    private $pass;
    private $database;

    private $link;

    /**
     * Connection constructor.
     */
    public function __construct() {
        $this->host = 'commitsoft.com.br';
        $this->user = 'commitso_conduct';
        $this->pass = 'Silverxwk190';
        $this->database = 'commitso_conductorhackathon';
    }

    public function openLink() {
        $this->link = mysqli_connect($this->host, $this->user, $this->pass, $this->database) or die('Sem conexao com o banco de dados');
        return $this->link;
    }

    public function close() {
        @mysqli_close($this->link);
    }

    /**
     * @return mixed
     */
    public function getLink()
    {
        return $this->link;
    }



}
