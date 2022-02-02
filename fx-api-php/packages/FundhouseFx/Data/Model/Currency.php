<?php
namespace FundhouseFx\Data\Model;


class Currency {
    public $currency_id;
    public $currency_name;
    public $currency_iso_code;
    public $currency_symbol;
    
    function __construct(int $id, string $name, string $iso_code, string $symbol)
    {
        $this->currency_id = $id;
        $this->currency_name = $name;
        $this->currency_iso_code = $iso_code;
        $this->currency_symbol = $symbol;
    }
}
?>