<?php
    namespace FundhouseFx\Api\Responses;

    class Quote {
        public string $base_currency;
        public string $quote_currency;
        public float $base_amount;
        public float $converted_amount;

        function __construct(string $base_ccy, string $quote_ccy, float $amount, float $converted_amount)
        {
            $this->base_currency = $base_ccy;
            $this->quote_currency = $quote_ccy;
            $this->base_amount = $amount;
            $this->converted_amount = $converted_amount;
        }
    }
?>