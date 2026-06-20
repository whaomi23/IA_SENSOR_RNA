# IA_SENSOR_RNA

## Descripción

IA_SENSOR_RNA es una aplicación desarrollada en C# con Windows Forms que permite capturar datos de sensores de temperatura y humedad mediante comunicación serial (puerto COM), procesarlos y generar automáticamente archivos de entrenamiento para una Red Neuronal Artificial (RNA).

El sistema recibe información en formato JSON desde dispositivos externos como Arduino o ESP32, almacena patrones de entrada y salida, y genera un archivo `.pml` que puede ser utilizado para entrenar modelos de inteligencia artificial.

---

## Características

* Detección automática de puertos COM disponibles.
* Comunicación serial con dispositivos externos.
* Recepción de datos en formato JSON.
* Procesamiento de temperatura y humedad.
* Generación automática de patrones de entrenamiento.
* Almacenamiento de patrones en archivos `.pml`.
* Interfaz gráfica desarrollada con Windows Forms.
* Soporte para múltiples vistas mediante controles de usuario.
* Validación para evitar patrones duplicados.

---

## Tecnologías Utilizadas

* C#
* .NET Framework
* Windows Forms
* SerialPort
* JSON Serialization
* Programación Orientada a Objetos (POO)

---

## Funcionamiento

### 1. Selección de Vista

Al iniciar la aplicación, el usuario puede elegir entre:

* Vista 1: Formulario principal.
* Vista 2: Control alternativo personalizado.

### 2. Detección de Puertos

La aplicación busca automáticamente los puertos COM disponibles en el equipo.

### 3. Recepción de Datos

El dispositivo externo envía información en formato JSON:

```json
{
  "temperatura": 25.4,
  "humedad": 68.7
}
```

### 4. Procesamiento

Los datos recibidos se convierten en patrones de entrada para la red neuronal:

```text
[temperatura, humedad, 0]
```

### 5. Generación de Salidas

El sistema genera automáticamente valores de salida secuenciales del 1 al 9 para cada patrón registrado.

### 6. Creación del Archivo PML

Una vez registrados los patrones, el sistema genera un archivo `.pml` con la estructura necesaria para el entrenamiento de la red neuronal.

### 7. Finalización Automática

Cuando se registran 8 patrones válidos:

* Se guarda el archivo.
* Se cierra el puerto serial.
* La aplicación finaliza automáticamente.

---

## Estructura del Proyecto

```text
IA_SENSOR_RNA/
│
├── Form1.cs
├── Vista2Control.cs
├── DatosSensor.cs
├── Ejemplo2.pml
├── Program.cs
└── Resources/
```

---

## Clase DatosSensor

Representa la información recibida desde el sensor:

```csharp
public class DatosSensor
{
    public double temperatura { get; set; }
    public double humedad { get; set; }
}
```

---

## Objetivo del Proyecto

Automatizar la captura de datos ambientales y generar conjuntos de entrenamiento para redes neuronales artificiales, facilitando el desarrollo de sistemas inteligentes basados en sensores físicos.

---

## Autor

Proyecto desarrollado como práctica de integración entre sensores, comunicación serial e inteligencia artificial utilizando C# y Windows Forms.
