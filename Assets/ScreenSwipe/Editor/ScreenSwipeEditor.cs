﻿using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ScreenSwipe))]
public class ScreenSwipeEditor : Editor
{
	// editing
	SerializedProperty _editingScreen;

    // parent scrollview
    SerializedProperty _parentScrollView;

	//swipe
	SerializedProperty _swipeType;
	SerializedProperty _swipeTime;
	SerializedProperty _swipeVelocityThreshold;
	SerializedProperty _skipScreenVelocityThreshold;

	// content
	SerializedProperty _maskContent;
	SerializedProperty _content;
	SerializedProperty _spacing;
	SerializedProperty _pagination;
	SerializedProperty _currentScreen;
	SerializedProperty _startingScreen;
	SerializedProperty _screens;

	// screen change events
	SerializedProperty _pollForScreenOrientationChange;
	SerializedProperty _editorRefreshKey;

	// controlls
	SerializedProperty _isInteractable;
	SerializedProperty _nextButton;
	SerializedProperty _previousButton;
	SerializedProperty _disableButtonsAtEnds;

	// tween
	SerializedProperty _tweenTime;

	// events
	SerializedProperty _onScreenDrag;
	SerializedProperty _onScreenChanged;

	private void OnEnable()
	{
		// editing
		_editingScreen = serializedObject.FindProperty("editingScreen");

        // parent scroll view
        _parentScrollView = serializedObject.FindProperty("ParentScrollView");

        // swipe
        _swipeType = serializedObject.FindProperty("swipeType");
		_swipeTime = serializedObject.FindProperty("swipeTime");
		_swipeVelocityThreshold = serializedObject.FindProperty("swipeVelocityThreshold");
		_skipScreenVelocityThreshold = serializedObject.FindProperty("skipScreenVelocityThreshold");

		// content
		_maskContent = serializedObject.FindProperty("maskContent");
		_content = serializedObject.FindProperty("content");
		_spacing = serializedObject.FindProperty("spacing");
		_pagination = serializedObject.FindProperty("pagination");
		_currentScreen = serializedObject.FindProperty("currentScreen");
		_startingScreen = serializedObject.FindProperty("startingScreen");
		_screens = serializedObject.FindProperty("screens");

		// screen change
		_pollForScreenOrientationChange = serializedObject.FindProperty("pollForScreenOrientationChange");
		_editorRefreshKey = serializedObject.FindProperty("editorRefreshKey");

		// controlls
		_isInteractable = serializedObject.FindProperty("isInteractable");
		_nextButton = serializedObject.FindProperty("nextButton");
		_previousButton = serializedObject.FindProperty("previousButton");
		_disableButtonsAtEnds = serializedObject.FindProperty("disableButtonsAtEnds");

		// tween
		_tweenTime = serializedObject.FindProperty("tweenTime");

		// events
		_onScreenDrag = serializedObject.FindProperty("onScreenDragBegin");
		_onScreenChanged = serializedObject.FindProperty("onScreenChanged");
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		var _target = (ScreenSwipe)target;

		// editing
		EditorGUILayout.PropertyField(_editingScreen);
		if (GUILayout.Button("GoToScreen"))
			_target.EditingScreen();

        // parent scrollview
        EditorGUILayout.PropertyField(_parentScrollView);

		//swipe
		EditorGUILayout.PropertyField(_swipeType);
		EditorGUILayout.PropertyField(_swipeTime);
		EditorGUILayout.PropertyField(_swipeVelocityThreshold);

		// contents
		EditorGUILayout.PropertyField(_maskContent);
		EditorGUILayout.PropertyField(_content);
		EditorGUILayout.PropertyField(_spacing);
		EditorGUILayout.PropertyField(_pagination);
		EditorGUILayout.PropertyField(_currentScreen);
		EditorGUILayout.PropertyField(_startingScreen);
		EditorGUILayout.PropertyField(_screens, true);

		//screen
		EditorGUILayout.PropertyField(_pollForScreenOrientationChange);
		if (_target.pollForScreenOrientationChange)
			EditorGUILayout.PropertyField(_editorRefreshKey);

		// controlls
		EditorGUILayout.PropertyField(_isInteractable);
		EditorGUILayout.PropertyField(_nextButton);
		EditorGUILayout.PropertyField(_previousButton);
		if (_target.NextButton != null || _target.PreviousButton != null)
			EditorGUILayout.PropertyField(_disableButtonsAtEnds);

		// tween
		EditorGUILayout.PropertyField(_tweenTime);

		//events
		EditorGUILayout.PropertyField(_onScreenDrag);
		EditorGUILayout.PropertyField(_onScreenChanged);

		serializedObject.ApplyModifiedProperties();
	}
}