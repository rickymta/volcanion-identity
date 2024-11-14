# Arguments
ARG POSTGRES_VERSION="14.13-alpine"

# Use the official PostgreSQL 16 image
FROM postgres:${POSTGRES_VERSION}

# Set environment variables for PostgreSQL
# These environment variables will be used to create database, user and password for PostgreSQL
ENV POSTGRES_DB=postgres
ENV POSTGRES_USER=postgres
ENV POSTGRES_PASSWORD=postgres

# Copy the SQL file to initialize the database if any
# If there is a SQL script to initialize the table or seed data, you can put it in the /docker-entrypoint-initdb.d/ directory
# Docker will automatically run the SQL files in this directory when initializing the container
# Example:
# COPY ./init.sql /docker-entrypoint-initdb.d/

# Expose default port of PostgreSQL
EXPOSE 5432
