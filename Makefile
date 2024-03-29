MAKEFLAGS += --silent

BASEDIR=$(shell git rev-parse --show-toplevel)

all:
	dotnet build ${BASEDIR}/src/CPR.generator/CPR.generator.csproj /property:GenerateFullPaths=true /consoleloggerparameters:NoSummary
	FORMAT=notfound dotnet run --project src/CPR.generator

docker-test:
	docker-compose up --build --force-recreate --remove-orphans
	docker-compose down --remove-orphans -v

clean:
	rm -rf ${BASEDIR}/src/CPR.generator/{bin,obj}
