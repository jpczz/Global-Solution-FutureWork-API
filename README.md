🎓 FutureWork API — Global Solution (FIAP)

API RESTful completa construída em .NET 8, seguindo as melhores práticas REST, com Entity Framework Core, SQL Server, versionamento e documentação via Swagger/OpenAPI.
Este projeto atende 100% dos requisitos oficiais da Global Solution.

# 🎓 FutureWork API — Global Solution (FIAP)

API RESTful desenvolvida em **.NET 8**, com **Entity Framework Core**, **SQL Server** e **Swagger**, abordando o tema **Futuro do Trabalho**.  
A aplicação permite gerenciar competências importantes para as profissões do futuro, com versionamento completo da API (v1 e v2).

---

## 🚀 Tecnologias Utilizadas

- **.NET 8 (ASP.NET Core Web API)**
- **C# 12**
- **SQL Server 2022 Developer**
- **Entity Framework Core 8 (Migrations)**
- **Swagger / OpenAPI 3.0**
- **Versionamento por Rotas (v1 e v2)**

---

## 📁 Estrutura da Solução



FutureWork/
├── FutureWork.API/
│ ├── Controllers/
│ │ ├── SkillsController.cs # API Versão 1
│ │ └── SkillsV2Controller.cs # API Versão 2
│ ├── Models/
│ │ ├── Skill.cs
│ │ └── SkillResponseV2.cs
│ ├── Data/
│ │ └── FutureWorkDbContext.cs
│ ├── Migrations/
│ ├── appsettings.json
│ ├── Program.cs
│ └── ...
└── README.md


---

# ✅ Requisitos Atendidos (FIAP)

## **1️⃣ Boas Práticas REST (30 pts)**

✔ Verbos HTTP usados corretamente:  
`GET`, `POST`, `PUT`, `DELETE`

✔ Status codes implementados corretamente:  
- `200 OK`  
- `201 Created`  
- `204 No Content`  
- `400 Bad Request`  
- `404 Not Found`

✔ Validações com Data Annotations:  
- `[Required]`  
- `[MaxLength]`

✔ Retornos consistentes e padronizados

---

## **2️⃣ Versionamento da API (10 pts)**

✔ Versão 1: `/api/v1/skills` (CRUD completo)  
✔ Versão 2: `/api/v2/skills` (DTO aprimorado)  
✔ Controllers organizados por versão  
✔ Swagger configurado com abas separadas (V1 e V2)  
✔ `ApiExplorerSettings(GroupName = "...")` para separar endpoints

### Diferenças entre as versões:

| Versão | Modelo de Retorno | Finalidade |
|--------|--------------------|------------|
| **v1** | `Skill` | CRUD padrão |
| **v2** | `SkillResponseV2` | Evolução com campo `ImportanceLevel` |

---

## **3️⃣ Integração & Persistência (30 pts)**

✔ Banco SQL Server  
✔ Entity Framework Core 8  
✔ Migrations aplicadas:



InitialCreate
AddSkillValidation


✔ DbContext configurado  
✔ Atualização automática do banco

---

## **4️⃣ Documentação (30 pts)**

✔ Swagger com duas versões  
✔ Títulos, descrição, contato, licença  
✔ Agrupamento de rotas por versão  
✔ Comentários e organização do código  
✔ Arquitetura documentada  

---

# 🛠 Rotas da API

## 🔹 **V1 — CRUD Completo**

### ➤ GET  
`/api/v1/skills`

### ➤ GET por ID  
`/api/v1/skills/{id}`

### ➤ POST  
Exemplo:

```json
{
  "name": "Inteligência Artificial",
  "category": "Tecnologia",
  "description": "Uso de IA para resolver problemas complexos.",
  "isFutureCritical": true
}

➤ PUT

/api/v1/skills/{id}

➤ DELETE

/api/v1/skills/{id}

🔹 V2 — Retorno Avançado com DTO
➤ GET

/api/v2/skills

Modelo de retorno:
{
  "id": 1,
  "name": "Inteligência Artificial",
  "category": "Tecnologia",
  "description": "Uso de IA para resolver problemas complexos.",
  "isFutureCritical": true,
  "importanceLevel": "Alta"
}

🏗 Arquitetura da Solução
[ CLIENTE ]
Swagger / Postman / Front-End
        |
        v
[ FutureWork.API (.NET 8) ]
- Controllers v1/v2
- Validações REST
- Versionamento
- Swagger/OpenAPI
        |
        v
[ Entity Framework Core ]
- DbContext
- Linq
- Migrations
        |
        v
[ SQL Server 2022 ]
- Banco: FutureWorkDB
- Tabela: Skills
