
## REDIS
- Pobranie obrazu
~~~
docker pull redis:latest
~~~

- Wyświetlenie pobranych obrazów
~~~
docker images
~~~

- Uruchomienie kontenera
~~~
docker run --name my-redis -d -p 6379:6379 redis
~~~

- Uruchomienie klienta **redis-cli** w trybie interaktywnym
~~~
docker exec -it my-redis redis-cli
~~~

