<?php
    namespace FundhouseFx\Api\Responses;
    
    class SpotRate {
        public $timestamp;
        public $value;

        public function __construct(int $timestamp, float $value){
            $this->timestamp = date(\DateTimeInterface::ATOM, $timestamp);
            $this->value = $value;
        }
    }
?>