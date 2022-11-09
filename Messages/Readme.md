# Message Bus
## Origin
Inspired by Jeffrey Palermo: [Jeffrey@Github](https://github.com/jeffreypalermo)
- [blazor-wasm-single-web-api](https://github.com/jeffreypalermo/blazor-wasm-single-web-api)
- [Blazor MVC](https://github.com/jeffreypalermo/blazormvc)

## UI Message Bus

```mermaid
graph TD;
    A-->B;
    A-->C;
    B-->D;
    C-->D;
```

## API Message Bus
```mermaid
classDiagram
class BankAccount
BankAccount : +String owner
BankAccount : +BigDecimal balance
BankAccount : +deposit(amount)
BankAccount : +withdrawal(amount)
```