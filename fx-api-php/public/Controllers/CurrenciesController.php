<?php
    use FundhouseFx\Api\Responses\Currency;
    use Psr\Container\ContainerInterface;
    use Psr\Http\Message\ResponseInterface as Response;
    use Psr\Http\Message\ServerRequestInterface as Request;
    use Psr\Http\Message\ResponseInterface;

    class CurrenciesController {
        private $container;

        public function __construct(ContainerInterface $container)
        {
            $this->container = $container;
        }

        public function get_currencies(Request $request, Response $response, array $args): ResponseInterface
        {
            $db = $this->container->get('FxDatabase');
            $currencies = $db->get_currencies();
            
            $mapped = array_map(function($ccy){
                return new Currency(
                    $ccy->currency_name,
                    $ccy->currency_iso_code,
                    $ccy->currency_symbol
                );
            }, $currencies);
        
            $body = json_encode($mapped);
        
            $response->getBody()->write($body);
        
            return $response
                ->withHeader('Access-Control-Allow-Origin', 'http://localhost:3000')
                ->withHeader('Content-Type', 'application/json')
                ->withStatus(200);
        }
    }
