
# Autonomous Conveyor Belt System for Sorting 3 Colors and 3 Sizes

This project is an Arduino-based embedded system that automatically classifies objects moving on a conveyor belt according to their **color** and **size**.

The system identifies objects as **red, green, or blue** and as **small, medium, or large**. The detected information is transmitted to a C# Windows Forms application through serial communication, where it is displayed and reported in real time using a column chart.

## Project Objective

The aim of this project is to develop a prototype of an automated sorting system that can be used as a basic model for industrial production lines.

The system performs the following operations:

- Detects an object on the conveyor belt.
- Determines the object's size using three sensor levels.
- Stops the object in front of the color sensor.
- Classifies the object as red, green, or blue.
- Sends the size and color information to the C# application.
- Activates the appropriate servo motor to direct the object to the correct section.
- Displays the number of sorted objects on a chart.
- Allows the operator to manually correct counters in case of an incorrect reading.

## System Features

- Detection of 3 colors:
  - Red
  - Green
  - Blue

- Detection of 3 sizes:
  - Small
  - Medium
  - Large

- Arduino Mega-based control system
- TCS3200 color sensor
- TCRT5000 infrared sensors for size and position detection
- Conveyor belt control using an L298N motor driver
- Mechanical sorting using 4 SG90 servo motors
- C# Windows Forms user interface
- Bidirectional serial communication
- Real-time product counters and column chart
- Manual correction feature for incorrect readings

## How the System Works

1. The conveyor belt starts moving.
2. When an object reaches the size detection section, it is detected by the lower sensor.
3. According to the states of the middle and upper sensors, the object is labeled as:
   - `SMALL`
   - `MEDIUM`
   - `LARGE`
4. When the object reaches the color sensor, the conveyor belt stops briefly.
5. The red, green, and blue channel values are read from the TCS3200 sensor.
6. The object's color is classified as:
   - `RED`
   - `GREEN`
   - `BLUE`
   - `UNKNOWN`
7. The Arduino sends the result to the C# application in the following format:

```text
SIZE,COLOR
```

Example:

```text
MEDIUM,RED
```

8. The C# application updates the product counter and chart.
9. The appropriate servo motor is activated according to the detected color and size.
10. The system continues waiting for the next object.

> Note: The current Arduino and C# source code uses Turkish serial messages such as `KUCUK`, `ORTA`, `BUYUK`, `KIRMIZI`, `YESIL`, `MAVI`, and `BELIRSIZ`. These values must remain unchanged unless both applications are updated together.

## Hardware Components

| Component | Purpose |
|---|---|
| Arduino Mega 2560 | Main control unit |
| TCS3200 color sensor | Detects the object's color |
| 4 × TCRT5000 sensors | Size detection and color-station triggering |
| 4 × SG90 servo motors | Direct objects into the correct sections |
| L298N motor driver | Controls the conveyor belt motor |
| 6V DC motor | Drives the conveyor belt |
| 2 × LM2596 buck converters | Regulate motor and servo supply voltages |
| 12V 4A power adapter | Main power supply |
| Conveyor belt mechanism | Transports objects through the system |

## Arduino Pin Connections

### Motor Driver

| Arduino Mega Pin | Connection |
|---|---|
| 33 | L298N IN1 |
| 35 | L298N IN2 |

### TCS3200 Color Sensor

| Arduino Mega Pin | TCS3200 Pin |
|---|---|
| 4 | S0 |
| 5 | S1 |
| 6 | S2 |
| 7 | S3 |
| 8 | OUT |

### TCRT5000 Sensors

| Arduino Mega Pin | Function |
|---|---|
| A0 | Middle size sensor |
| A1 | Color-station trigger sensor |
| A2 | Lower size sensor |
| A3 | Upper size sensor |

### Servo Motors

| Arduino Mega Pin | Function |
|---|---|
| 12 | Red-object sorting servo |
| 28 | Green-object sorting servo |
| 23 | Blue-object sorting servo |
| 22 | Large-object sorting servo |

> The ground lines of the Arduino, sensors, motor driver, and power modules must be connected together.

## Technologies Used

### Embedded System

- Arduino Mega 2560
- Arduino IDE
- C / C++
- Servo library
- Analog sensor readings
- Serial communication

### Desktop Application

- C#
- .NET Windows Forms
- `System.IO.Ports`
- `System.Windows.Forms.DataVisualization.Charting`
- MSChart

## Serial Communication Protocol

Serial communication between the Arduino and the C# application operates at `9600 baud`.

### Messages Sent from Arduino to the C# Application

| Message | Description |
|---|---|
| `DUR` | Indicates that the conveyor belt has stopped for color measurement |
| `CALIS` | Indicates that the conveyor belt has started moving again |
| `SIZE,COLOR` | Sends the detected object's classification result |

Example data packets used by the current source code:

```text
KUCUK,MAVI
ORTA,YESIL
BUYUK,KIRMIZI
```

### Commands Sent from the C# Application to Arduino

| Command | Description |
|---|---|
| `START` | Starts the conveyor belt |
| `STOP` | Stops the conveyor belt |

## Sensor Filtering and Calibration

To reduce noise in the analog values read from the TCRT5000 sensors, each sensor is read 10 times and the average value is used.

The TCS3200 color sensor is calibrated when the system starts. The raw red, green, and blue channel values are converted to the `0-255` range using predefined minimum and maximum values.

The detected color is selected according to the dominant RGB channel.

> Sensor threshold values should be recalibrated depending on ambient lighting, object surfaces, and sensor positions.

## C# User Interface

The Windows Forms application includes the following features:

- Arduino serial-port connection
- Conveyor belt start and stop controls
- Colored system-status panel
- Display of the most recently detected color and size
- Counters for nine different color-size combinations
- Column chart for visualizing product quantities
- Manual counter reduction for incorrect classifications

### Status Colors

| Color | System Status |
|---|---|
| Green | Conveyor belt is running |
| Yellow | Conveyor belt is stopped for color measurement |
| Red | System has been stopped by the operator |

## Installation

### 1. Uploading the Arduino Code

1. Connect the Arduino Mega 2560 to the computer.
2. Open the Arduino IDE.
3. Make sure the `Servo.h` library is available.
4. Open the Arduino source code.
5. Select `Arduino Mega or Mega 2560` as the board.
6. Select the correct COM port.
7. Upload the code to the board.

### 2. Running the C# Application

1. Open the project in Visual Studio.
2. Make sure Windows Forms and Chart components are available.
3. Update the serial-port name in `Form1_Load` according to the Arduino port on the computer.

Example:

```csharp
serialPort1.PortName = "COM10";
serialPort1.BaudRate = 9600;
```

4. Build and run the project.
5. If the Arduino connection is successful, the application will begin reading serial data.

## Usage

1. Check all power and wiring connections.
2. Connect the Arduino to the computer.
3. Start the C# application.
4. Start the conveyor belt.
5. Place an object at the beginning of the conveyor belt.
6. Wait for the object to pass through the size and color detection stages.
7. Monitor the result in the application and chart.
8. If an incorrect classification occurs, select the relevant color and size and reduce the corresponding counter.

## Recommended Repository Structure

```text
.
├── Arduino/
│   └── ConveyorSortingSystem.ino
├── CSharp/
│   └── ConveyorSortingSystem.sln
├── docs/
│   ├── block-diagram.png
│   ├── flowchart.png
│   └── interface.png
└── README.md
```

## Project Images

After adding the project images to the repository, the following Markdown links can be used:

```markdown
![System Block Diagram](docs/block-diagram.png)

![System Flowchart](docs/flowchart.png)

![C# User Interface](docs/interface.png)
```

## Important Notes

- The COM port in the C# application may be different on each computer.
- Sensor threshold values must be calibrated according to the physical setup.
- Servo motors should not be powered directly from the Arduino's 5V pin.
- A separate regulated power supply should be used for the servo motors and DC motor.
- All system components must share a common ground.
- Servo timing delays should be adjusted according to the conveyor belt speed and servo positions.
- The TCS3200 sensor can be affected by ambient light, so the sensing area should be covered as much as possible.

## Possible Improvements

- Automatic COM port detection
- Sensor threshold configuration through the user interface
- Database storage for product records
- Daily, weekly, and monthly production reports
- CSV or Excel export
- Error logging system
- Emergency stop button
- PWM-based conveyor speed control
- More advanced color calibration
- Web-based remote monitoring dashboard
- Scaling the system with industrial sensors and motors

## Project Owner

**Murat Enes Ulusoy**

Course: **Microprocessors and Embedded Systems**

Project: **Autonomous Conveyor Belt System for Sorting 3 Colors and 3 Sizes**
