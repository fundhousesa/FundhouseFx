<?php
    use FundhouseFx\Api\Responses\SpotRate;
    use Psr\Container\ContainerInterface;
    use Psr\Http\Message\ResponseInterface as Response;
    use Psr\Http\Message\ServerRequestInterface as Request;
    use Psr\Http\Message\ResponseInterface;

    class SpotRatesController {
        private $container;

        public function __construct(ContainerInterface $container)
        {
            $this->container = $container;
        }

        public function get_historic_spot_rates(Request $request, Response $response, array $args): ResponseInterface
        {            
            // TODO: Validate input parameters and return the appropriate HTTP error response code if invalid
            $base = $args['base'];
            $quote = $args['quote'];

            // TODO: Fail gracefully if an unsupported currency is specified
            $db = $this->container->get('FxDatabase');
            $base_ccy = $db->find_currency($base);
            $quote_ccy = $db->find_currency($quote);

            /*
             * TODO: Cater for the case where we have spot rates for the two selected currencies,
             * but in the wrong direction.
             *
             * The other case is of course where neither of the requested currencies are ZAR.
             * Is it possible to derive the exchange rate?
             */
            $spots = $db->get_spot_rates($base_ccy->currency_id, $quote_ccy->currency_id);
            
            $mapped = array_map(function($spot){
                return new SpotRate(
                    $spot->timestamp,
                    $spot->value
                );
            }, $spots);

            $body = json_encode($mapped);
            
            $response->getBody()->write($body);

            return $response->withHeader('Content-Type', 'application/json')->withStatus(200);
        }
    }
