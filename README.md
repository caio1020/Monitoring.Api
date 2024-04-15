# Monitoring.Api

Tecnologias utilizadas

Dot Net 6.0
Entity framework
PostgreSQL

Instruções do banco de dados:

1 - Necessario ter o DBeaver ou SQL Server instalado

2 - Alterar a connectionString na pasta appsettings do projeto

3 - Executar o seguinte comando: update-database

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                                                                                                        MonitoringApi Documentation
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Serviço: "Sensores"

MÉTODOS:

POST - /api/Sensores
Api para inserir os sensores
Parameters:
Name	              Type	                      Description
Id	                int	                        Id do sensor
Codigo	            string	                    Codigo do sensor

GET - /api/Sensores/listartodos
Retorna uma lista de sensores cadastrados.

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Serviço: "SetorEquipamento"

MÉTODOS:

GET - /api/SetorEquipamento/listartodos
Retorna uma lista de setores ou equipamentos cadastrados.

POST - /api/SetorEquipamento
Api para inserir o setor ou equipamento
Parameters:
Name	                            Type	                          Description
nome	                            string	                        Nome do setor ou do equipamento


POST - /api/SetorEquipamento/vincularsensor
Api para vincular o setor ou equipamento a um sensor
Parameters:
Name	                            Type	                          Description
IdSensor	                        int	                            Id do sensor. OBS(Recuperar id no metodo "GET - /api/Sensores/listartodos" do serviço "Sensores")
IdSetorEquipamento	              int	                            Id do setor ou equipamento. OBS(Recuperar id no metodo "GET - /api/SetorEquipamento/listartodos" do serviço "SetorEquipamento")

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Serviço: "Medicao"

MÉTODOS:

GET - /api/Medicao/ultimas-medicoes/{idSetorEquipamento}
Retorna as últimas 10 medições de todos os sensores vinculados a um setor ou equipamento.
Parameters:
Name	                            Type	                           Description
idSetorEquipamento	              int	                             Id do setor ou equipamento. OBS(Recuperar id no metodo "GET - /api/SetorEquipamento/listartodos" do serviço "SetorEquipamento")

POST - /api/Medicao
Api para inserir a medição a um sensor

Parameters:
Name	                            Type	                            Description
SensorId	                        int	                              Id do sensor. OBS(Recuperar id no metodo "GET - /api/Sensores/listartodos" do serviço "Sensores")
Valor	                            decimal	                          Valor da medição
DataHora	                        DateTime	                        Data da medição
