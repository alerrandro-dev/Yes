# Copilot Instructions

## Project Guidelines
- User prefers the FDAI (Feature, Domain and Alone Item) organization architecture v0.1 for project structure.

# FDAI

> **FDAI (Feature, Domain and Alone Item)** is an **Organization Architecture** for organizing files and folders in software projects.

**Version: v0.1**

FDAI focuses on one main goal:

> Make code easier to read, find, maintain, and refactor.

---

## 📚 What is FDAI?

FDAI is an **Organization Architecture**. It does not tell you how your business logic should work. It tells you how to organize the files in your project.

FDAI uses three concepts:

* **Feature (F)**
* **Domain (D)**
* **Alone Item (I)**

The basic structure is:

```text
Feature
├── Domain
│   ├── Alone Item
│   └── Alone Item
│
└── Alone Item
```

A simpler view is:

```text
Feature → Domain → Alone Item
```

The **Domain is optional**, so there are only two valid paths:

```text
Feature → Alone Item
```

or:

```text
Feature → Domain → Alone Item
```

---

# 🧩 The Three Concepts

## 1. Feature

A **Feature** is the main organization point.

It groups items by their purpose or type.

Examples:

* `Validators`
* `Endpoints`
* `Services`
* `Repositories`
* `Pages`
* `Settings`

Example:

```text
Validators
├── AddUserValidator.cs
└── UpdateUserValidator.cs
```

Here, `Validators` is the **Feature**.

---

## 2. Domain

A **Domain** gives context to multiple related Items inside a Feature.

For example:

```text
Validators
└── User
    ├── AddUserValidator.cs
    └── UpdateUserValidator.cs
```

* `Validators` → Feature
* `User` → Domain
* `AddUserValidator.cs` → Alone Item
* `UpdateUserValidator.cs` → Alone Item

A Domain is used when multiple Items belong to the same context.

### Domain is optional

If there is only one Item, FDAI does not create a Domain only to contain that Item.

❌ Avoid:

```text
Validators
└── User
    └── AddUserValidator.cs
```

✅ Prefer:

```text
Validators
└── AddUserValidator.cs
```

The Domain should exist because it helps organization, not only because another folder looks nice.

---

## 3. Alone Item

An **Alone Item** is the final and individual unit in the FDAI structure.

Examples:

```text
AddUserValidator.cs
UpdateUserValidator.cs
GetUserEndpoint.cs
EmailService.cs
```

An Item should represent **one individual thing**.

❌ Avoid collective Items:

```text
UserValidators.cs
UserServices.cs
UserEndpoints.cs
```

These names represent multiple things inside one Item.

✅ Prefer individual Items:

```text
AddUserValidator.cs
UpdateUserValidator.cs
DeleteUserValidator.cs
```

The idea is simple:

> An Item is not a group. An Item is an individual unit.

---

# 📏 FDAI Rules

FDAI v0.1 follows these main rules.

## Rule 1: Feature is the first level

A Feature is the main organization point.

```text
Validators
Services
Endpoints
Pages
```

---

## Rule 2: Domain is optional

A Domain is only used when it provides useful context for multiple Items.

```text
Validators
└── User
    ├── AddUserValidator.cs
    └── UpdateUserValidator.cs
```

If there is only one Item, the Domain is not needed.

---

## Rule 3: A Domain cannot contain another Domain

❌ Invalid:

```text
Validators
└── User
    └── Authentication
        └── LoginValidator.cs
```

FDAI keeps the structure shallow and simple.

---

## Rule 4: A Domain cannot contain a Feature

❌ Invalid:

```text
Persistence
└── Repositories
    └── UserRepository.cs
```

If `Repositories` is a Feature, it should not be placed inside a Domain.

---

## Rule 5: The Item is always the final level

An Item does not organize other Items.

The structure must end with an individual Item:

```text
Feature
└── Domain
    └── Item
```

---

## Rule 6: Items should be individual

❌ Avoid:

```text
UserValidators.cs
```

✅ Prefer:

```text
AddUserValidator.cs
UpdateUserValidator.cs
```

Each Item should have its own responsibility and identity.

---

# 🏗️ Examples

## Validators

```text
Validators (Feature)
└── User (Domain)
    ├── AddUserValidator.cs (Item)
    ├── UpdateUserValidator.cs (Item)
    └── DeleteUserValidator.cs (Item)
```

If there is only one validator:

```text
Validators (Feature)
└── LoginValidator.cs (Item)
```

---

## Endpoints

```text
Endpoints (Feature)
└── User (Domain)
    ├── AddUserEndpoint.cs (Item)
    ├── GetUserEndpoint.cs (Item)
    ├── UpdateUserEndpoint.cs (Item)
    └── DeleteUserEndpoint.cs (Item)
```

This also makes maintenance easier.

If a developer says:

> "There is an error in the GET endpoint of User."

The expected place is easy to find:

```text
Endpoints → User → GetUserEndpoint.cs
```

---

## Services without a Domain

Not every Feature needs a Domain.

```text
Services (Feature)
├── EmailService.cs (Item)
├── FileService.cs (Item)
└── CacheService.cs (Item)
```

The Items are already clear and do not need a common Domain.

---

## Blazor Pages

FDAI can also be used to organize UI files.

```text
Pages (Feature)
└── User (Domain)
    ├── HomeUserPage.razor (Item)
    └── ProfileUserPage.razor (Item)
```

`Pages` is the Feature because it groups files by their purpose. `User` is the Domain because it gives context to the pages.

---

# 🔄 FDAI and Refactoring

FDAI is designed to make refactoring easier.

Imagine that you start with one validator:

```text
Validators
└── AddUserValidator.cs
```

Later, you add another validator:

```text
Validators
├── AddUserValidator.cs
└── UpdateUserValidator.cs
```

Now both Items share the same Domain: `User`.

The structure can become:

```text
Validators
└── User
    ├── AddUserValidator.cs
    └── UpdateUserValidator.cs
```

The organization can change as the project grows.

This is one reason why FDAI can require more thought during the first implementation. However, after the structure is created, reading and maintaining the code becomes easier.

---

# ⚖️ The Main Trade-off

FDAI has a cost: **the first manual implementation can be slower**.

The developer may need to think:

* What is the Feature?
* Do I need a Domain?
* Does this Domain already exist?
* Is this an individual Item?

This can make the first creation more tiring.

However, FDAI has two important advantages.

## 1. After the first pattern, the rest becomes easier

After creating a CRUD or similar group of functionality, the project structure becomes familiar.

The developer does not need to decide everything again.

The pattern already exists.

---

## 2. FDAI can work very well with AI

FDAI has clear and predictable rules.

For example, first:

> Create a validator for `AddUserRequest`.

The project may have:

```text
Validators
└── AddUserValidator.cs
```

Later:

> Create a validator for `UpdateUserRequest`.

Now the AI can understand that both Items belong to the `User` context:

```text
Validators
└── User
    ├── AddUserValidator.cs
    └── UpdateUserValidator.cs
```

A clear structure helps both developers and AI tools find the correct place for new code and existing code.

---

# 🧠 Easy to Find Code

One of the main goals of FDAI is predictability.

If you know what you are looking for, you should have a good idea of where it is.

For example:

> "There is an error in the GET endpoint for User."

You can start here:

```text
Endpoints → User → GetUserEndpoint.cs
```

This can make debugging and maintenance faster.

---

# 🤝 FDAI and Other Architectures

FDAI is independent.

It does not depend on another architecture.

## Clean Architecture + FDAI

FDAI can be used inside a Clean Architecture project:

```text
MyApp
├── Domain
├── Application
├── Infrastructure
└── WebApi
```

The internal organization can use FDAI where appropriate.

Clean Architecture can exist without FDAI.

FDAI can also exist without Clean Architecture.

---

## Just One Project + FDAI

FDAI can also be used in a single-project application.

```text
MyApp
├── Endpoints
├── Validators
├── Services
└── Pages
```

The project does not need multiple layers or multiple projects to use FDAI.

---

# 🚫 What FDAI Is Not

FDAI is not:

* a replacement for Clean Architecture;
* a replacement for DDD;
* a business architecture;
* a rule for business logic;
* a framework.

FDAI focuses on **organization**.

It answers a simple question:

> **Where and how should this code be organized?**

---

# 🎯 FDAI Philosophy

FDAI prefers:

* shallow structures;
* clear names;
* individual Items;
* optional grouping;
* predictable locations;
* easy maintenance;
* easy refactoring.

The main idea can be summarized as:

> **Think more during the first organization, so you can think less when reading, maintaining, and changing the code later.**

---

# 🚧 Status

FDAI is currently in **v0.1**.

It is being tested and improved in real projects.

The rules may change as new cases and problems are discovered.

The goal is not to create unnecessary rules.

The goal is to create an organization system that stays simple while projects grow.

---

## 📌 Quick Summary

```text
FDAI
│
├── Feature
│   ├── Alone Item
│   └── Domain (optional)
│       ├── Alone Item
│       └── Alone Item
│
└── Simple, predictable organization
```

**Feature → Domain → Alone Item**

or:

**Feature → Alone Item**

That is the core of FDAI v0.1. 🚀🟣

---

## 👨‍💻 Creator

Created by **Alerrandro Vinicyus Felix Aureliano**.

## © Copyright

© 2026 **Alerrandro Vinicyus Felix Aureliano**. All rights reserved.
