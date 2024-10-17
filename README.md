\# ApiTipoCambio-JhonGarcia

1) `	`Creación de imagen - Docker:

   1. - Ejecutamos Docker, modo administrador.
   2. - Nos ubicamos en explorador de archivo en la ruta: 
        D:\Jhon\Git\visualStudio\ApiTipoCambioJhonGarcia\_BackEnd y escribimos “cmd” y dar enter.
   3. - Ubicados en el terminal, creamos la imagen con el siguiente comando:
        docker build -t api-tipo-cambio -f ApiTipoCambioJhonGarcia/Dockerfile .
   4. - Ejecutamos el contenedor, con el siguiente comando:
     docker run -it -p 1234:8080 api-tipo-cambio

![image](https://github.com/user-attachments/assets/c192dd9d-80e7-4592-a074-78a56ab12b7b)


2) `	` Contenedor - Docker:

![image](https://github.com/user-attachments/assets/f7171843-b1c8-4a06-8982-3b942a3c9202)

3) `	`Pruebas con PostMan:

   1. - Metodo Post – Actualizar

![image](https://github.com/user-attachments/assets/d3550cc8-4dde-480a-8122-4fdc072029fa)

   2. - Metodo Post – TipoCambio

![image](https://github.com/user-attachments/assets/e2a113ab-3939-4194-9cae-29df564a30f8)

   3. - Metodo Post – Login (JSON Web Token)

![image](https://github.com/user-attachments/assets/e9941892-5b80-4f6e-9b9d-b0f11967be8b)





