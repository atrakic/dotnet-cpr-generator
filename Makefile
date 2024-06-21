MAKEFLAGS += --silent

BASEDIR=$(shell git rev-parse --show-toplevel)

all:
	dotnet build ${BASEDIR}/src/DkCprGenerator/DkCprGenerator.csproj /property:GenerateFullPaths=true /consoleloggerparameters:NoSummary
	dotnet run --project ${BASEDIR}/src/DkCprGenerator --format plain --limit 5

docker-test:
	docker-compose up --build --force-recreate --remove-orphans

clean:
	docker-compose down --remove-orphans -v
	rm -rf ${BASEDIR}/src/DkCprGenerator/{bin,obj,build}
