<?php
    use FundhouseFx\Api\Responses\Quote;
    use Psr\Container\ContainerInterface;
    use Psr\Http\Message\ResponseInterface as Response;
    use Psr\Http\Message\ServerRequestInterface as Request;
    use Psr\Http\Message\ResponseInterface;

    class QuotesController {
        private $container;

        public function __construct(ContainerInterface $container)
        {
            $this->container = $container;
        }

        public function get_quote(Request $request, Response $response, array $args): ResponseInterface
        {
            /*
             * [TODO]: 
             *  -   Perform the currency conversion using the **latest** available spot rate.
             *      As per the specification, you are expected to create a Quote result 
             *      (see FundhouseFx\Api\Responses\Quote).
             *  -   Cater for the case where we have spot rates for the two selected currencies,
             *      but in the wrong direction.
             *  -   The other case is of course where neither of the requested currencies are ZAR.
             *      Is it possible to derive the exchange rate for the quote?
             */
            return $response->withStatus(501);
        }
    }
