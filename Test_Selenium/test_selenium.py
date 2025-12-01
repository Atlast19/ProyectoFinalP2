from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.chrome.service import Service
from selenium.webdriver.common.keys import Keys
from datetime import datetime
import traceback
import time
import webbrowser

# ==========================
# CONFIGURACIÓN DEL DRIVER
# ==========================

service = Service("C:\\Users\\Ahlea\\Downloads\\chromedriver-win64\\chromedriver-win64\\chromedriver.exe")

chrome_options = webdriver.ChromeOptions()

# Evitar alertas de seguridad de contraseñas
chrome_options.add_argument("--disable-features=PasswordManagerUI")
chrome_options.add_argument("--disable-features=IsolateOrigins,site-per-process")
chrome_options.add_argument("--disable-notifications")
chrome_options.add_argument("--disable-save-password-bubble")
chrome_options.add_argument("--disable-extensions")

driver = webdriver.Chrome(service=service, options=chrome_options)

# Lista para almacenar resultados
resultados = []


# ==========================
# FUNCIÓN PARA REGISTRAR RESULTADOS
# ==========================
def registrar_resultado(nombre, estado, mensaje=""):
    resultados.append({
        "test": nombre,
        "estado": estado,
        "mensaje": mensaje
    })


# ==========================
# FUNCIÓN PARA ESCRIBIR CON JS
# ==========================
def escribir_js(driver, element_id, texto):
    try:
        elemento = driver.find_element(By.ID, element_id)
        driver.execute_script("arguments[0].value = arguments[1];", elemento, texto)
    except Exception as e:
        raise Exception(f"Error al escribir en {element_id}: {e}")


# ============================================================
# =====================   PRUEBAS    =========================
# ============================================================

# ---------------------------------
# 1. Cargar página principal
# ---------------------------------
try:
    driver.get("http://localhost/PaginaDelProyecto/")
    registrar_resultado("Cargar página", "OK", "Página cargó correctamente.")
except Exception:
    registrar_resultado("Cargar página", "ERROR", traceback.format_exc())


# ---------------------------------
# 2. LOGIN
# ---------------------------------
ID_USUARIO = "loginName"
ID_PASSWORD = "loginPass"
ID_BOTON_LOGIN = "Ingresar"

USUARIO_PRUEBA = "Admin"
PASSWORD_PRUEBA = "Admin"

try:
    time.sleep(2)

    escribir_js(driver, ID_USUARIO, USUARIO_PRUEBA)
    escribir_js(driver, ID_PASSWORD, PASSWORD_PRUEBA)

    driver.find_element(By.ID, ID_BOTON_LOGIN).click()
    time.sleep(2)

    registrar_resultado("Login", "OK", "Login realizado correctamente.")
except Exception:
    registrar_resultado("Login", "ERROR", traceback.format_exc())


# ============================================================
# ==========   PANEL DE USUARIOS (AGREGAR USUARIO)   =========
# ============================================================

try:
    # Ir al panel
    driver.find_element(By.ID, "usuario").click()
    time.sleep(1)

    escribir_js(driver, "nameUser", "Usuario Test")
    escribir_js(driver, "ageUser", "1990-05-10")
    escribir_js(driver, "matriculaUser", "2025001")
    escribir_js(driver, "emailUser", "correo@test.com")
    escribir_js(driver, "passwordUser", "12345")

    driver.find_element(By.ID, "btnUsuario").click()
    time.sleep(1)

    registrar_resultado("Agregar Usuario", "OK", "Usuario agregado correctamente.")

except Exception:
    registrar_resultado("Agregar Usuario", "ERROR", traceback.format_exc())


# ============================================================
# ==========   PANEL DE CURSOS (AGREGAR CURSO)   =============
# ============================================================

try:
    driver.find_element(By.ID, "curso").click()
    time.sleep(1)

    escribir_js(driver, "nombreMaestro", "Profesor Test")
    escribir_js(driver, "nombreMateria", "Matemáticas")
    escribir_js(driver, "turno", "Matutino")
    escribir_js(driver, "horasInicioCurso", "08:00")
    escribir_js(driver, "horaFinalCurso", "10:00")
    escribir_js(driver, "fechaFinCurso", "2025-12-31")
    escribir_js(driver, "horaFinCurso", "18:00")
    escribir_js(driver, "espaciosDisponibles", "30")

    driver.find_element(By.ID, "btnCurso").click()
    time.sleep(1)

    registrar_resultado("Agregar Curso", "OK", "Curso agregado correctamente.")

except Exception:
    registrar_resultado("Agregar Curso", "ERROR", traceback.format_exc())


# ============================================================
# =====================  LOGOUT  =============================
# ============================================================

try:
    driver.find_element(By.ID, "salir").click()
    registrar_resultado("Logout", "OK", "Cierre de sesión exitoso.")
except Exception:
    registrar_resultado("Logout", "ERROR", "No se pudo cerrar sesión.")


# Cerrar navegador
driver.quit()


# ============================================================
# =============== GENERAR REPORTE HTML ========================
# ============================================================

fecha = datetime.now().strftime("%Y-%m-%d %H:%M")

# ============================================================
# =============== GENERAR REPORTE HTML DINÁMICO ==============
# ============================================================

from datetime import datetime

# Contadores
total_tests = len(resultados)
passed = sum(1 for r in resultados if r["estado"] == "OK")
failed = sum(1 for r in resultados if r["estado"] != "OK")

status_global = "TODAS LAS PRUEBAS PASARON 🎉" if failed == 0 else "HAY PRUEBAS FALLIDAS ❌"

color_global = "#28a745" if failed == 0 else "#dc3545"

fecha = datetime.now().strftime("%Y-%m-%d %H:%M:%S")

html = f"""
<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Reporte de Pruebas Selenium</title>
    <style>
        body {{
            font-family: Arial, sans-serif;
            background: #eef1f5;
            padding: 20px;
        }}

        .card {{
            background: white;
            padding: 25px;
            border-radius: 12px;
            max-width: 1000px;
            margin: auto;
            box-shadow: 0 0 12px rgba(0,0,0,0.15);
        }}

        h1 {{
            text-align: center;
            margin-bottom: 10px;
            color: #333;
        }}

        .status-global {{
            text-align: center;
            font-size: 20px;
            font-weight: bold;
            padding: 15px;
            border-radius: 8px;
            color: white;
            background: {color_global};
            margin-bottom: 25px;
        }}

        .stats {{
            display: flex;
            justify-content: space-around;
            margin-bottom: 25px;
        }}

        .box {{
            background: #f8f9fa;
            padding: 15px;
            border-radius: 8px;
            width: 30%;
            text-align: center;
            border-left: 5px solid #007bff;
        }}

        .passed {{
            color: #28a745;
            font-weight: bold;
        }}

        .failed {{
            color: #dc3545;
            font-weight: bold;
        }}

        table {{
            width: 100%;
            border-collapse: collapse;
        }}

        th {{
            background: #007bff;
            color: white;
            padding: 12px;
        }}

        td {{
            padding: 10px;
        }}

        tr:nth-child(even) {{
            background: #f2f2f2;
        }}

        .ok {{
            color: #28a745;
            font-weight: bold;
        }}

        .error {{
            color: #dc3545;
            font-weight: bold;
        }}

        pre {{
            white-space: pre-wrap;
            background: #f8f9fa;
            padding: 8px;
            border-radius: 5px;
        }}
    </style>
</head>
<body>

<div class="card">

    <h1>Reporte de Pruebas Automatizadas</h1>
    <p><strong>Fecha:</strong> {fecha}</p>

    <div class="status-global">{status_global}</div>

    <div class="stats">
        <div class="box">
            <h3>Total de pruebas</h3>
            <p>{total_tests}</p>
        </div>

        <div class="box">
            <h3>Aprobadas ✔️</h3>
            <p class="passed">{passed}</p>
        </div>

        <div class="box">
            <h3>Falladas ❌</h3>
            <p class="failed">{failed}</p>
        </div>
    </div>

    <table>
        <tr>
            <th>Prueba</th>
            <th>Estado</th>
            <th>Detalle</th>
        </tr>
"""

# Agregar resultados
for r in resultados:
    estado = "ok" if r["estado"] == "OK" else "error"

    html += f"""
        <tr>
            <td>{r['test']}</td>
            <td class="{estado}">{r['estado']}</td>
            <td><pre>{r['mensaje']}</pre></td>
        </tr>
    """

html += """
    </table>
</div>

</body>
</html>
"""

# Crear archivo HTML
with open("reporte.html", "w", encoding="utf-8") as f:
    f.write(html)

print("Reporte generado: reporte.html")
webbrowser.open("reporte.html")