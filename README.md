# ERP Core Libraries

Este repositorio contiene el núcleo lógico y técnico de la suite ERP. Está diseñado bajo los principios de **Clean Architecture** y **Domain-Driven Design (DDD)** para garantizar que la lógica de negocio sea independiente de los frameworks, la interfaz de usuario y la persistencia.

## 🏗️ Estructura de Capas

La solución se divide en cuatro paquetes principales, cada uno con una responsabilidad única dentro del ecosistema:

### 1. `ERP.Core.Domain`
El corazón del sistema. Contiene la lógica de negocio pura que no cambia frecuentemente.
* **Contenido:** Entidades de dominio, Objetos de Valor (Value Objects), Excepciones de dominio y lógica de validación esencial.
* **Regla:** Esta capa tiene **cero dependencias** externas.

### 2. `ERP.CoreDatabase.Domain`
Extensión especializada para la definición de esquemas y modelos de persistencia.
* **Contenido:** Definiciones de modelos de datos, configuraciones de entidades para ORMs y constantes relacionadas con la estructura de la base de datos.
* **Propósito:** Centralizar el esquema de datos para asegurar la consistencia en entornos multi-tenant.

### 3. `ERP.Core.Application`
Define los casos de uso del sistema. Orquesta el flujo de datos desde y hacia las entidades de dominio.
* **Contenido:** DTOs (Data Transfer Objects), Mappers, Interfaces de servicios externos y manejadores de comandos/consultas (CQRS).
* **Dependencia:** Depende únicamente de `ERP.Core.Domain`.

### 4. `ERP.Core.Infrastructure`
Contiene las implementaciones técnicas de las interfaces definidas en las capas internas.
* **Contenido:** Implementación de repositorios, integración con servicios de terceros (Email, Storage), acceso a base de datos y seguridad (JWT, Encriptación).
* **Dependencia:** Depende de `ERP.Core.Application` y `ERP.CoreDatabase.Domain`.

---

## 🚀 Tecnologías Principales

* **.NET 9+ / .NET 10**
* **Entity Framework Core** (Persistencia)
* **MediatR** (Comunicación desacoplada entre capas)
* **FluentValidation** (Validación de entrada y reglas de negocio)

---

## 🛠️ Instalación y Uso

Estos paquetes están diseñados para ser consumidos como dependencias internas o publicados a través de un feed privado de NuGet (GitHub Packages).

Para agregar el núcleo a un nuevo microservicio o módulo:

```bash
dotnet add package ERP.Core.Database.Domain


dotnet add package ERP.Core.Domain
dotnet add package ERP.Core.Application
dotnet add package ERP.Core.Infrastructure