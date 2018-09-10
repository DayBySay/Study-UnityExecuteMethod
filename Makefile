UNITY_CLI?=/Applications/Unity/Unity.app/Contents/MacOS/Unity
PROJ_PATH?=$(shell pwd)
LOG_FILE?=unity-cli.log

install:
	git lfs pull
	bundle install --path=vendor/bundle

build-ios:
	$(UNITY_CLI) \
		-executeMethod ExportTool.ExportXcodeProject \
		-buildTarget ios \
		-projectPath $(PROJ_PATH) \
		-nographics \
		-batchmode \
		-logfile $(LOG_FILE) \
		-quit
