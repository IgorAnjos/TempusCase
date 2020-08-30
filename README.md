# TempusCase
## Desafio Tempus Digital 
___

## Configuração

Abrir o arquivo **appsettings.Development** e configurar a conexão local, inser o seu login e senha do banco
* "DefaultConnection": "Server=.;Database=DB-TempusCase;user=;password="
  
No VisualStudio abrir o Package Manager Console e executar os seguintes comandos
* Update-Database -Context ApplicationDbContext
* Update-Database -Context DataDbContext

Inicializar com o projeto **UI** 

ctrl+F5 ou F5 para ver a aplicação rodando!!
