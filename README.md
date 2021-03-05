# Locadora

Configuração

1 - Configure o Sql Server
  *Crie o usuario 'LocadoraAPI' com a senha = 'senha';
  execute o script \Locadora\DATABASE_FIRST.sql no Sql Server;
  
Teste

2 - Abra o projeto no Visual Code e execute =  dotnet run

3 - Abra o postman e insira o seguinte endpoint :http://localhost:5000/api/filme/
  *Utiliza os metodos:
    GET  /{id} Ex: http://localhost:5000/api/filme/1
    GET        Ex:http://localhost:5000/api/filme
    
    POST http://localhost:5000/api/filme
          Body [ json com a descrição do objeto ]
    
    PUT  /{id}  Ex: http://localhost:5000/api/filme/5
          Body [ json com a descrição do objeto ]
    
    DELETE  /{id}     Ex:http://localhost:5000/api/filme/3
    DELETE(mais de 1) Ex:http://localhost:5000/api/filme/
          Body [ 1,2,4,44 ]
          
    
