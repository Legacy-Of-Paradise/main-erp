@echo off
cd ../../

call python ./RUN_THIS.py
call dotnet msbuild -p:Configuration=Debug -verbosity:minimal -consoleloggerparameters:Summary

pause
