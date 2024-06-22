# syntax=docker/dockerfile:1
ARG IMAGE_TAG=8.0
ARG IMAGE_BUILD=dotnet/sdk
ARG IMAGE_RUNTIME=dotnet/runtime

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/${IMAGE_BUILD}:${IMAGE_TAG} as base
ARG TARGETARCH
WORKDIR /src

FROM base AS build-env
COPY src/DkCprGenerator .
RUN dotnet restore -a $TARGETARCH

FROM build-env AS publish
RUN dotnet publish -a $TARGETARCH --no-restore -o /app/publish

FROM mcr.microsoft.com/${IMAGE_RUNTIME}:${IMAGE_TAG}-alpine AS final
WORKDIR /app
COPY --from=publish /app/publish .
USER $APP_UID
ENTRYPOINT ["dotnet", "DkCprGenerator.dll"]
