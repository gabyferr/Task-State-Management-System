# Task-State-Management-System

✨ Sistema de Gerenciamento de Estados de Tarefas

 📌 Requisitos do Sistema
 
- Endpoints RESTful
  POST /tasks
PUT /tasks/{id}/start
PUT /tasks/{id}/complete
PUT /tasks/{id}/cancel
GET /tasks/{id}
 
- Padrão State
Utilização do padrão State para estados de tarefas.
Estados: Created, In Progress, Completed, Cancel.
Classe Task com id, name, description.

 📌Siga estas etapas para usar esse projeto:

Baixe ou clone esse repositório

No terminal digite o comando para criar o banco de dados:

 ✨ update-database

❗ Atenção
 O projeto já possui uma migration BD. Caso não tenha, utilize os seguintes comandos:

1° add-migration teste
--
2° update-database
