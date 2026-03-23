# Predictor

## Descripción

**Predictor** es una aplicación web desarrollada en **C# con ASP.NET Core MVC** que permite analizar series de datos históricos de activos financieros y generar predicciones de tendencia utilizando diferentes métodos estadísticos y matemáticos.

El usuario ingresa 20 pares de datos (fecha, valor) y selecciona un modo de predicción. La aplicación procesa los datos y muestra el resultado junto con la tendencia estimada (alcista o bajista).

### Modos de predicción disponibles

| Modo | Descripción |
|------|-------------|
| **Media Móvil Simple (SMA) Crossover** | Compara la media de los últimos 5 períodos con la media de los 20 períodos para detectar cruces de tendencia. |
| **Regresión Lineal** | Ajusta una recta a los 20 valores históricos y predice el valor del siguiente período. |
| **Momentum (ROC)** | Calcula la tasa de cambio (Rate of Change) de cada período respecto a 5 períodos anteriores para medir el impulso del activo. |

---

## Estructura del Proyecto

El repositorio sigue una arquitectura en capas que separa responsabilidades claramente:

```
Predictor/
├── Predictor.sln                  # Solución de Visual Studio
├── Application/                   # Capa de aplicación (orquestación)
│   ├── Interfaces/                # Contratos de los servicios de predicción
│   ├── Services/                  # Implementaciones: SMA, Regresión Lineal, Momentum
│   │   ├── SmaService.cs
│   │   ├── RegresionLinealService.cs
│   │   ├── MomentumService.cs
│   │   └── PrediccionManager.cs   # Factory de selección de modo
│   ├── DTOs/                      # Objetos de transferencia de datos de la capa de aplicación
│   ├── Enums/                     # Enumeraciones (ModoPrediccion)
│   └── ViewModels/
├── Logica/                        # Capa de lógica de negocio
│   ├── Interfaces/                # Contrato IPredictionService
│   ├── Services/                  # PredictionService con los algoritmos de cálculo
│   ├── Models/                    # Modelos del dominio y Singleton del modo activo
│   └── DTOs/                      # DTOs de resultados y datos de entrada
└── Predictor/                     # Capa de presentación (ASP.NET Core MVC)
    ├── Controllers/               # HomeController, PredictionController
    ├── Views/                     # Vistas Razor (Home, Prediction)
    ├── ViewModels/                # ViewModels de la UI
    ├── wwwroot/                   # Archivos estáticos (JS, CSS, librerías)
    └── appsettings.json
```

### Descripción de cada capa

- **Application**: Orquesta los modos de predicción a través de `PrediccionManager` (patrón Factory) e interfaces que desacoplan las implementaciones del resto del sistema.
- **Logica**: Contiene los algoritmos matemáticos para cada modo de predicción (`PredictionService`). Implementa el patrón Singleton para gestionar el modo de predicción activo en la sesión.
- **Predictor**: Proyecto web ASP.NET Core MVC. Los controladores reciben la entrada del usuario, delegan el cálculo a la capa `Logica` y devuelven las vistas con los resultados.

---

## Requisitos Previos

Asegúrese de tener instaladas las siguientes herramientas antes de compilar y ejecutar el proyecto:

| Herramienta | Versión mínima recomendada | Enlace |
|-------------|----------------------------|--------|
| **.NET SDK** | 6.0 o superior | [dotnet.microsoft.com](https://dotnet.microsoft.com/download) |
| **Visual Studio** *(opcional)* | 2022 o superior (con carga de trabajo *ASP.NET y desarrollo web*) | [visualstudio.microsoft.com](https://visualstudio.microsoft.com/) |
| **Git** | Cualquier versión reciente | [git-scm.com](https://git-scm.com/) |

> También puede usar **Visual Studio Code** con la extensión **C# Dev Kit** como alternativa a Visual Studio.

---

## Instrucciones de Instalación y Ejecución

### 1. Clonar el repositorio

```bash
git clone https://github.com/eudyyuniorramires/Predictor.git
cd Predictor
```

### 2. Restaurar paquetes NuGet

```bash
dotnet restore
```

### 3. Compilar la solución

```bash
dotnet build
```

### 4. Ejecutar la aplicación

```bash
cd Predictor
dotnet run
```

La aplicación estará disponible por defecto en `http://localhost:5000` (o la URL indicada en la consola). Ábrala en su navegador para acceder a la interfaz.

### Ejecución desde Visual Studio

1. Abra `Predictor.sln` con Visual Studio 2022.
2. Establezca el proyecto **Predictor** como proyecto de inicio.
3. Presione **F5** (con depuración) o **Ctrl+F5** (sin depuración) para ejecutar.

---

## Uso

1. Acceda a la aplicación en su navegador.
2. Seleccione un **modo de predicción** en la sección correspondiente (SMA, Regresión Lineal o Momentum).
3. Ingrese **exactamente 20 pares de datos** en el formato `AAAA-MM-DD, valor` (uno por línea). Ejemplo:

```
2024-01-01, 100.5
2024-01-02, 102.3
2024-01-03, 101.8
...
```

4. Haga clic en **Calcular** para obtener el resultado y la tendencia estimada.

---

## Contribución

¡Las contribuciones son bienvenidas! Para colaborar, siga estos pasos:

1. **Haga un fork** del repositorio y cree una rama descriptiva a partir de `main`:
   ```bash
   git checkout -b feature/nombre-de-la-funcionalidad
   ```

2. **Realice sus cambios** siguiendo las convenciones del proyecto (nombres en inglés para símbolos de código, separación por capas).

3. **Asegúrese de que el proyecto compila y funciona** correctamente antes de enviar:
   ```bash
   dotnet build
   dotnet run --project Predictor
   ```

4. **Haga commit** con un mensaje claro y descriptivo:
   ```bash
   git commit -m "feat: descripción del cambio realizado"
   ```

5. **Envíe un Pull Request** hacia la rama `main` describiendo el propósito y los cambios introducidos.

### Pautas generales

- Mantenga la separación de capas existente (Application / Logica / Predictor).
- Agregue nuevos modos de predicción implementando la interfaz `IPredictionService` en la capa `Logica` y registrando la selección en `PrediccionManager`.
- Escriba código limpio, legible y en español o inglés de forma consistente con el módulo donde trabaje.

---

## Licencia

Este proyecto es de uso educativo. Consulte con el autor para cualquier uso comercial o redistribución.
