<?php
    namespace FundhouseFx\Api\Responses;

    class Currency {
        public $name;
        public $code;
        public $symbol;

        function __construct(string $name, string $code, string $symbol)
        {
            $this->name = $name;
            $this->code = $code;
            $this->symbol = $symbol;
        }
    }
?>