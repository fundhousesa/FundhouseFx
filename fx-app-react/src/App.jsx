import React from "react";
import { Alert, Button, Divider, Form, InputNumber, Select, Table, Tooltip, TooltipProps, Typography } from 'antd';
import { SwapOutlined } from '@ant-design/icons';
import './App.css';

const api = 'http://localhost:8080';

const { Option } = Select;
const { Title } = Typography;

const Annotation = ({ text, placement, children }) => (
  <Tooltip
    title={text}
    placement={placement}
    color="#ff8d02"
    visible
  >
    {children}
  </Tooltip>
)

const App = () => {
  const [currencies, setCurrencies] = React.useState([]);
  const [baseCurrency, setBaseCurrency] = React.useState(undefined);
  const [quoteCurrency, setQuoteCurrency] = React.useState(undefined);
  const [amountPrefix, setAmountPrefix] = React.useState('?');
  const [amount, setAmount] = React.useState(1);
  const [quote, setQuote] = React.useState(undefined);

  const gridColumns = [{
    title: 'Timestamp',
    dataIndex: 'timestamp',
    key: 'timestamp'
  }, {
    title: 'Rate',
    dataIndex: 'value',
    key: 'value'
  }];

  const rates = [{
    timestamp: "2021-11-29T00:00:00+00:00",
    value: 0.06163328197226502
  },
  {
    timestamp: "2021-11-26T00:00:00+00:00",
    value: 0.061614294516327786
  },
  {
    timestamp: "2021-11-25T00:00:00+00:00",
    value: 0.06291286568103177
  },
  {
    timestamp: "2021-11-24T00:00:00+00:00",
    value: 0.06285592165637925
  },
  {
    timestamp: "2021-11-23T00:00:00+00:00",
    value: 0.06301693580149666
  }];

  React.useEffect(() => {
    async function getCurrencies() {
      let response = await fetch(`${api}/currencies`);
      if (response.ok) {
        let body = await response.json();

        setCurrencies(body || []);
      }
    }
    getCurrencies();
  }, [])

  const handleAmountChanged = value => {
    if (value) {
      setAmount(value);
    }
  }

  const handleBaseCurrencySelected = value => {
    if (value) {
      let ccy = currencies.find(_ => _.code === value);

      setBaseCurrency(ccy);
      setAmountPrefix(ccy.symbol);
    }
  };

  const handleQuoteCurrencySelected = value => {
    if (value) {
      let ccy = currencies.find(_ => _.code === value);

      setQuoteCurrency(ccy);
    }
  }

  return (
    <div className="fx-app">
      <div className="fx-ui-wrapper">
        <Title style={{ textAlign: 'center' }}>Fundhouse FX</Title>

        <Form layout="inline" className="fx-currency-conversion-form">
          <Form.Item name="amount">
            <InputNumber
              addonBefore={amountPrefix}
              placeholder="Amount"
              defaultValue={1}
              onChange={handleAmountChanged}
            />
          </Form.Item>
          <Form.Item name="base-ccy">
            <Select
              showSearch
              placeholder="Select a base currency"
              onChange={handleBaseCurrencySelected}
            >
              {currencies.map(ccy => (
                <Option key={ccy.code} value={ccy.code}>{ccy.symbol} - {ccy.name}</Option>
              ))}
            </Select>
          </Form.Item>
          <Form.Item>
            <Annotation text="Switch function requires implementation" placement="bottomRight">
              <Button icon={<SwapOutlined />} title="Switch" />
            </Annotation>
          </Form.Item>
          <Form.Item name="quote-ccy">
            <Select
              showSearch
              placeholder="Select a quote currency"
              onChange={handleQuoteCurrencySelected}
            >
              {currencies.map(ccy => (
                <Option key={ccy.code} value={ccy.code}>{ccy.symbol} - {ccy.name}</Option>
              ))}
            </Select>
          </Form.Item>
          <Form.Item shouldUpdate>
            <Annotation text="Should be disabled when no selection has been made" placement="right">
              <Button
                type="primary"
                htmlType="button"
              >Convert</Button>
            </Annotation>
          </Form.Item>
        </Form>

        <Divider />

        <div className="fx-quote">
          <Annotation text="Currently static. Integrate with API." placement="right">
            <span className="fx-quote-amount">$1,000</span><span>=</span><span className="fx-quote-amount">R15,000</span>
          </Annotation>
        </div>

        <Divider />

        <Annotation text="Currently static data. Integrate with API." placement="topLeft">
          <Table columns={gridColumns} dataSource={rates} pagination={false} />
        </Annotation>

        <Alert
          message="Hint:"
          description="Is a table really the best way to display the historic exchange rates?"
          type="info"
          showIcon
        />
      </div>
    </div >
  )
}

export default App;