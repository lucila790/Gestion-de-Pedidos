# Gestión de Pedidos

Aplicación de escritorio desarrollada en C# con Windows Forms, utilizando la arquitectura **MVC** y conectada a una base de datos **SQL Server**.

## 📝 Objetivo

Sistema de gestión de pedidos que permite administrar **clientes**, **productos** y **pedidos**, cumpliendo con los siguientes requisitos académicos:

- Arquitectura MVC
- Uso de base de datos relacional
- Módulo ABM de entidades (Clientes, Productos)
- Listados con filtros
- Implementación de **UserControl** para consultas

---

## ⚙️ Tecnologías utilizadas

- **Lenguaje:** C# (.NET Framework)
- **Entorno de desarrollo:** Visual Studio 2022 o superior
- **Base de datos:** SQL Server 2019+
- **Componentes:** Windows Forms, DataGridView, UserControl

---

## 🗂️ Estructura del proyecto

El proyecto está dividido en **3 capas** (3 proyectos):
/GestionPedido (Windows Forms - Vistas)
/GestionPedidos.Models (Biblioteca de clases - Modelos)
/GestionPedidos.Controller (Biblioteca de clases - Controladores)


---

## 🗄️ Base de datos

La base de datos se llama **GestionPedidos** e incluye las siguientes tablas:

- `Clientes`  
- `Productos`  
- `Pedidos` (relaciona Cliente y Forma de Pago)  
- `DetallePedidos` (detalle de productos por pedido)  
- `FormasDePago`  

> 📂 **Script de base de datos disponible** en el archivo: `GestionPedidos.sql`

---

## 🖥️ Funcionalidades principales

✅ **Formulario Principal (FrmPrincipal)**  
- Menú de navegación

✅ **ABM Clientes**  
- Agregar, Modificar, Eliminar clientes  
- Listado con filtro por nombre

✅ **Consulta de pedidos por cliente (UserControl)**  
- Seleccionar cliente y ver detalle de sus pedidos

---

## 🚀 Cómo ejecutar el proyecto

1. Clonar o descargar el proyecto.
2. Restaurar paquetes NuGet (si es necesario).
3. Configurar la cadena de conexión en `Conexion.cs` (proyecto Controller):
   ```csharp
   private static string cadenaConexion = "Server=localhost;Database=GestionPedidos;Trusted_Connection=True;";
