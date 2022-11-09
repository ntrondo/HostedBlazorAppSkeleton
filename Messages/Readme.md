# Message Bus
## Origin
Inspired by Jeffrey Palermo: [Jeffrey@Github](https://github.com/jeffreypalermo)
- [blazor-wasm-single-web-api](https://github.com/jeffreypalermo/blazor-wasm-single-web-api)
- [Blazor MVC](https://github.com/jeffreypalermo/blazormvc)

## UI Message Bus

```mermaid
flowchart
subgraph Client
direction LR
    A[Component1] --> B[Bus]
    B-->C[Component2]
    B-->D[Component2]
    end
```

## API Message Bus
```mermaid
flowchart RL
subgraph Client
    A[Component] --> B[Bus]
    B-.->A
    end
    subgraph Server
    C[Bus]-->D[Handler]
    D -.-> C
    end
    B-->C
    C-.->B
```

### Embedding charts:
- [Mermaid Documentation](https://mermaid-js.github.io/mermaid/#/)
- [Mermaid Live Editor](https://mermaid.live/)