<?php
    namespace FundhouseFx\Data\Model;

    class SpotRate {
        public $spot_rate_id;
        public $base_currency_id;
        public $quote_currency_id;
        public $timestamp;
        public $value;

        function __construct($id, $base_currency_id, $quote_currency_id, int $timestamp, float $value)
        {
            $this->spot_rate_id = $id;
            $this->base_currency_id = $base_currency_id;
            $this->quote_currency_id = $quote_currency_id;
            $this->timestamp = $timestamp;
            $this->value = $value;
        }
    }
?>