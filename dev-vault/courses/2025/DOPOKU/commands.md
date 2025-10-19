# Docker desktop:

winget install -e --id Docker.DockerDesktop

# vamos instalar docker desktop con WSL2.

# WSL2 ( Windows Subsystem for Linux 2)

Permite ejecutar un kernel de Linux completo en Windows, lo que permite ejecutar aplicaciones de Linux directamente en Windows sin necesidad de una máquina virtual completa.

wsl --install
wsl --set-default-version 2

docker run -it alpine:latest /bin/sh # Run a container with Alpine Linux and open a shell
uname -a # Shows the kernel version and architecture

docker ps
docker stop <container_id> # Stop a running container

wsl --list --online # List available Linux distributions for WSL

wsl --install -d <distro_name> # Install a specific Linux distribution for WSL

example: wsl --install -d Ubuntu-22.04

--

# Docker CLI commands:

docker --version # Check Docker version



## run a container
docker run hello-world # foreground run a container and print a message

-d # Run a container in detached mode (in the background)

--name <name> # Assign a name to the container

## list containers

docker ps # List running containers

-a # List all containers (running and stopped)

## remove a container

docker rm <container_id> # Remove a stopped container

docker rm $(docker ps -a -q) # Remove all stopped containers

# stop a container

docker stop <container_id> # Stop a running container

docker kill <container_id> # Forcefully stop a running container

# start a container

docker start <container_id> # Start a stopped container

# port mapping

We need to know two things:

- IP of the container
- Port of the container

Prácticas propuestas para el módulo

Borra la imagen dockercampusmvp/pingpong

docker rm $(docker ps -a -q) # Remove all stopped containers

docker rmi dockercampusmvp/pingpong

Crea dos contenedores de la imagen dockercampusmvp/pingpong. Hazlo en modo background. Asegúrate de que puedes comunicarte con ambos contenedores usando dos puertos a tu elección

docker run -d --name pingpong1 -p 8081:8080 dockercampusmvp/pingpong
docker run -d --name pingpong2 -p 8082:8080 dockercampusmvp/pingpong

Detén uno de los contenedores:

docker stop pingpong1

Verifica que no puedes conectarte con este contenedor

curl http://localhost:8081 # No debería responder

Reinícialo de nuevo

docker start pingpong1

Verifica que puedes conectarte con él de nuevo

curl http://localhost:8081 # Debería responder

¿Qué comando usarías para encontrar los ids de ambos contenedores?

docker ps -a # List all containers (running and stopped)
