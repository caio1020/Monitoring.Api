### Monitoring.Api

#### Tecnologias utilizadas

- Dot Net 6.0
- Entity Framework
- PostgreSQL

#### Instruções do banco de dados:

1. Necessário ter o DBeaver ou SQL Server instalado.
2. Alterar a connectionString na pasta `appsettings` do projeto.
3. Executar o seguinte comando: `update-database`.

---

### MonitoringApi Documentation

#### Serviço: "Sensores"

#### MÉTODOS:

**POST - /api/Sensores**

API para inserir os sensores.

Parameters:
- **Id**: int (Id do sensor)
- **Codigo**: string (Código do sensor)

**GET - /api/Sensores/listartodos**

Retorna uma lista de sensores cadastrados.

---

#### Serviço: "SetorEquipamento"

#### MÉTODOS:

**GET - /api/SetorEquipamento/listartodos**

Retorna uma lista de setores ou equipamentos cadastrados.

**POST - /api/SetorEquipamento**

API para inserir o setor ou equipamento.

Parameters:
- **nome**: string (Nome do setor ou do equipamento)

**POST - /api/SetorEquipamento/vincularsensor**

API para vincular o setor ou equipamento a um sensor.

Parameters:
- **IdSensor**: int (Id do sensor. OBS: Recuperar id no método "GET - /api/Sensores/listartodos" do serviço "Sensores")
- **IdSetorEquipamento**: int (Id do setor ou equipamento. OBS: Recuperar id no método "GET - /api/SetorEquipamento/listartodos" do serviço "SetorEquipamento")

---

#### Serviço: "Medicao"

#### MÉTODOS:

**GET - /api/Medicao/ultimas-medicoes/{idSetorEquipamento}**

Retorna as últimas 10 medições de todos os sensores vinculados a um setor ou equipamento.

Parameters:
- **idSetorEquipamento**: int (Id do setor ou equipamento. OBS: Recuperar id no método "GET - /api/SetorEquipamento/listartodos" do serviço "SetorEquipamento")

**POST - /api/Medicao**

API para inserir a medição a um sensor.

Parameters:
- **SensorId**: int (Id do sensor. OBS: Recuperar id no método "GET - /api/Sensores/listartodos" do serviço "Sensores")
- **Valor**: decimal (Valor da medição)
- **DataHora**: DateTime (Data da medição)
