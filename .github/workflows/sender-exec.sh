#!/bin/bash

export JAVA_PROGRAM_ARGS=`echo "$@"`
mvn compile exec:java -Dexec.mainClass="bmsstream.Sender" -Dexec.args="$JAVA_PROGRAM_ARGS"
